using Vegapunk.FrontEnd.Shaka.Models;

namespace Vegapunk.FrontEnd.Shaka.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto dto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto dto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}
