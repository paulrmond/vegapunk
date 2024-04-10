using Vegapunk.FrontEnd.Shaka.Models;

namespace Vegapunk.FrontEnd.Shaka.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);
        Task<ResponseDto?> CreatePaymentToken(YorkPaymentRequestDto cartDto);
        Task<ResponseDto?> GetAllOrder(string? userId);
        Task<ResponseDto?> GetOrder(int orderId);
        Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus);
    }
}
