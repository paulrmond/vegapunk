using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

using Vegapunk.FrontEnd.Shaka.Utility;

namespace Vegapunk.FrontEnd.Shaka.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {

            _baseService = baseService;

        }

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.OrderAPIBase + "/api/order/createorder",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> CreatePaymentToken(YorkPaymentRequestDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.OrderAPIBase + "/api/order/CreatePaymentToken",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> GetAllOrder(string? userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.OrderAPIBase + "/api/order/GetAllOrders?userId=" + userId
            });
        }

        public async Task<ResponseDto?> GetOrder(int orderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.OrderAPIBase + "/api/order/GetOrders/"+ orderId
            });
        }

        public async Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.OrderAPIBase + "/api/order/UpdateOrderStatus/"+orderId,
                Data = newStatus
            });
        }
    }
}
