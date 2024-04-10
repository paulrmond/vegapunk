using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using Vegapunk.Services.OrderAPI.Data;
using Vegapunk.Services.OrderAPI.Models;
using Vegapunk.Services.OrderAPI.Models.Dto;
using Vegapunk.Services.OrderAPI.Service.IService;
using Vegapunk.Services.OrderAPI.Utility;

namespace Vegapunk.Services.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private IProductService _productService;
        public OrderAPIController(AppDbContext dbContext, IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _productService = productService;
            this._response = new ResponseDto();
        }

        [HttpGet("GetAllOrders")]
        public async Task<ResponseDto> GetAllOrders(string userId)
        {
            try
            {
                IEnumerable<OrderHeader> objList = null;
                objList = await _dbContext.OrderHeaders.Include(x => x.OrderDetails).Where(x=> x.UserId == userId).ToListAsync();
                _response.Result = _mapper.Map<List<OrderHeaderDto>>(objList);
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetOrders/{id:int}")]
        public async Task<ResponseDto> GetOrders(int id)
        {
            try
            {
                OrderHeader header = await _dbContext.OrderHeaders.Include(x=>x.OrderDetails).FirstOrDefaultAsync(x=>x.OrderHeaderId == id);
                _response.Result = _mapper.Map<OrderHeaderDto>(header);
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("UpdateOrderStatus/{orderId:int}")]
        public async Task<ResponseDto> UpdateOrderStatus(int orderId, [FromBody] string newStatus)
        {
            try
            {
                OrderHeader header = await _dbContext.OrderHeaders.Where(x => x.OrderHeaderId == orderId).FirstOrDefaultAsync();
                if(header != null) 
                { 
                    if (newStatus == StaticData.StatusCancelled)
                    {
                        // Process Refund here
                    }
                    header.OrderStatus = newStatus;
                    _dbContext.SaveChanges();
                    _response.IsSuccess = true;
                }
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                
            }
            return _response;
        }

        [HttpPost("CreateOrder")]
        public async Task<ResponseDto> CreateOrder([FromBody] CartDto cartDto)
        {
            try
            {
                OrderHeaderDto orderHeaderDto = _mapper.Map<OrderHeaderDto>(cartDto.CartHeader);
                orderHeaderDto.OrderTime = DateTime.Now;
                orderHeaderDto.OrderStatus = StaticData.StatusPending;
                orderHeaderDto.OrderDetails = _mapper.Map<IEnumerable<OrderDetailsDto>>(cartDto.CartDetails);

                // Add and fetch the entity created
                OrderHeader orderCreated = _dbContext.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderHeaderDto)).Entity;
           
                await _dbContext.SaveChangesAsync();
                orderHeaderDto.OrderHeaderId = orderCreated.OrderHeaderId;
                _response.Result = orderHeaderDto;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("CreatePaymentToken")]
        public async Task<ResponseDto> CreatePaymentToken([FromBody] YorkPaymentRequestDto yorkPaymentRequestDto)
        {
            // Call payment API and get payment token
            // then return payment URL
            // shaka will redirect the webpage to payment URL
            return new ResponseDto();
        }
    }
}
