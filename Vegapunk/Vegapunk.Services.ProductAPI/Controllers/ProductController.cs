using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vegapunk.Services.ProductAPI.Data;
using Vegapunk.Services.ProductAPI.Models;
using Vegapunk.Services.ProductAPI.Models.Dto;

namespace Vegapunk.Services.ProductAPI.Controllers
{
    [Route("api/productapi")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public ProductController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> obj = _db.Products.ToList();

                //Auto convert Coupon model to CouponDto
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(obj);
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product obj = _db.Products.Where(x => x.ProductId == id).FirstOrDefault();
                _response.Result = _mapper.Map<ProductDto>(obj);
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Product obj = _db.Products.Where(x => x.ProductId.ToString() == code).FirstOrDefault();
                _response.Result = _mapper.Map<ProductDto>(obj);
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] ProductDto couponDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(couponDto);
                _db.Products.Add(obj);
                _db.SaveChanges();
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] ProductDto couponDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(couponDto);
                _db.Products.Update(obj);
                _db.SaveChanges();
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product obj = _db.Products.Find(id);
                _db.Products.Remove(obj);
                _db.SaveChanges();
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}
