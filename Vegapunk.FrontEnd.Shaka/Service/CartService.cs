using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;
using Vegapunk.FrontEnd.Shaka.Utility;

namespace Vegapunk.FrontEnd.Shaka.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.CouponAPIBase + "/api/cart/ApplyCoupon",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.ShoppingCartAPIBase + "/api/cart/GetCart/"+ userId
            });
        }

        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.CouponAPIBase + "/api/cart/RemoveCart/",
                Data = cartDetailsId
            });
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.ShoppingCartAPIBase + "/api/cart/CartUpsert/",
                Data = cartDto
            });
        }
    }
}
