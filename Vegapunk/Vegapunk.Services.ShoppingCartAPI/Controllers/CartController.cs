using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using Vegapunk.Services.ShoppingCartAPI.Data;
using Vegapunk.Services.ShoppingCartAPI.Models;
using Vegapunk.Services.ShoppingCartAPI.Models.Dto;
using Vegapunk.Services.ShoppingCartAPI.Service.IService;

namespace Vegapunk.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ResponseDto responseDto;
        private IMapper _mapper;
        private readonly AppDbContext _db;
        private IProductService productService;
        private ICouponService couponService;
        public CartController(AppDbContext _appDbContext, IMapper _mapper, IProductService productService, ICouponService couponService)
        {
            this._db = _appDbContext;
            this._mapper = _mapper;
            this.responseDto = new ResponseDto();
            this.productService = productService;
            this.couponService = couponService;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<ResponseDto> GetCart(string userId)
        {
            try
            {
                CartDto cart = new()
                {
                    CartHeader = _mapper.Map<CartHeaderDto>(_db.CartHeaders.First(x => x.UserId == userId))
                };

                cart.CartDetails = _mapper.Map<IEnumerable<CartDetailDto>>(_db.CartDetails.Where(x => x.CartHeaderId == cart.CartHeader.CarHeaderId).ToList());

                IEnumerable<ProductDto> productDtos = await this.productService.GetProducts();

                foreach (var item in cart.CartDetails)
                {
                    item.Product = productDtos.FirstOrDefault(x => x.ProductId == item.ProductId);
                    cart.CartHeader.CartTotal += (item.Count * item.Product.Amount);
                }

                //Apply coupon if any
                if(!string.IsNullOrEmpty(cart.CartHeader.CouponCode))
                {
                    CouponDto coupon = await this.couponService.GetCoupon(cart.CartHeader.CouponCode);
                    if(coupon != null && cart.CartHeader.CartTotal > coupon.MinAmouint)
                    {
                        cart.CartHeader.CartTotal -= coupon.DiscountAmount;
                        cart.CartHeader.Discount = coupon.DiscountAmount;
                    }
                }

                responseDto.Result = cart;
            }
            catch (Exception ex)
            {

                responseDto.Message = ex.Message.ToString();
                responseDto.IsSuccess = false;
            }
            return responseDto;
        }

        [HttpGet("ApplyCoupon")]
        public async Task<ResponseDto> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var cartFromDb = await _db.CartHeaders.FirstOrDefaultAsync(x=>x.UserId == cartDto.CartHeader.UserId);
                cartFromDb.CouponCode = cartDto.CartHeader.CouponCode;
                _db.Update(cartFromDb);
                await _db.SaveChangesAsync();

                responseDto.Result = true;
            }
            catch (Exception ex)
            {

                responseDto.Message = ex.Message.ToString();
                responseDto.IsSuccess = false;
            }
            return responseDto;
        }

        [HttpGet("RemoveCoupon")]
        public async Task<ResponseDto> RemoveCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var cartFromDb = await _db.CartHeaders.FirstOrDefaultAsync(x => x.UserId == cartDto.CartHeader.UserId);
                cartFromDb.CouponCode = "";
                _db.Update(cartFromDb);
                await _db.SaveChangesAsync();

                responseDto.Result = true;
            }
            catch (Exception ex)
            {

                responseDto.Message = ex.Message.ToString();
                responseDto.IsSuccess = false;
            }
            return responseDto;
        }

        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto) 
        {
            try
            {

                var cartHeaderFromDb = await _db.CartHeaders.Where(x => x.UserId == cartDto.CartHeader.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (cartHeaderFromDb == null) 
                {
                    //create header and details
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto);
                    _db.CartHeaders.Add(cartHeader);
                    await _db.SaveChangesAsync();
                    cartDto.CartDetails.First().CartHeaderId = cartHeader.CarHeaderId;
                    _db.CartDetails.Add(_mapper.Map<CartDetail>(cartDto.CartDetails.First()));
                    await _db.SaveChangesAsync();
                }
                else
                {
                    //if header is not null. check if details has same product
                    // EF has tracking.. gogle --> AsNoTracking() for more reference
                    var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == cartDto.CartDetails.FirstOrDefault().ProductId && x.CartHeaderId == cartHeaderFromDb.CarHeaderId);
                    if(cartDetailsFromDb == null)
                    {
                        //create cartdetails
                        cartDto.CartDetails.First().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                        _db.CartDetails.Add(_mapper.Map<CartDetail>(cartDto.CartDetails.First()));
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        //update count in cartdetails
                        cartDto.CartDetails.First().Count += cartDetailsFromDb.Count;
                        cartDto.CartDetails.First().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                        cartDto.CartDetails.First().CartDetailId = cartDetailsFromDb.CartDetailId;
                        _db.CartDetails.Update(_mapper.Map<CartDetail>(cartDto.CartDetails.First()));
                        await _db.SaveChangesAsync();
                    }
                    responseDto.Result = cartDto;
                }
            }
            catch (Exception ex)
            {

                responseDto.Message = ex.Message.ToString();
                responseDto.IsSuccess = false;
            }
            return responseDto;
        }

        [HttpPost("RemoveCart")]
        public async Task<ResponseDto> RemoveCart([FromBody]int cartDetailId)
        {
            try
            {
                CartDetail cartDetail = _db.CartDetails.FirstOrDefault(x=>x.CartDetailId == cartDetailId);
                int cartDetailCount = _db.CartDetails.Where(x=>x.CartHeaderId == cartDetail.CartHeaderId).Count();

                _db.CartDetails.Remove(cartDetail);
                if (cartDetailCount == 1)
                {
                    //create header and details
                    CartHeader cartHeaderToRemove = await _db.CartHeaders.FirstOrDefaultAsync(x=>x.CarHeaderId == cartDetail.CartHeaderId);
                    _db.CartHeaders.Remove(cartHeaderToRemove);
              
                }
                await _db.SaveChangesAsync();
                responseDto.Result = true;
            }
            catch (Exception ex)
            {

                responseDto.Message = ex.Message.ToString();
                responseDto.IsSuccess = false;
            }
            return responseDto;
        }
    }
}
