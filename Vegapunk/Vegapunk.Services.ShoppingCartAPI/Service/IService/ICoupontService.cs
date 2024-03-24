using Vegapunk.Services.ShoppingCartAPI.Models.Dto;

namespace Vegapunk.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
