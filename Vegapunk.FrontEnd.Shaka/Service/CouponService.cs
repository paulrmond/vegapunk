using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

using Vegapunk.FrontEnd.Shaka.Utility;

namespace Vegapunk.FrontEnd.Shaka.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.CouponAPIBase + "/api/couponapi",
                Data = dto
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.DELETE,
                Url = StaticData.CouponAPIBase + "/api/couponapi/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.CouponAPIBase + "/api/couponapi"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.CouponAPIBase + "/api/couponapi/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.CouponAPIBase + "/api/couponapi/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.PUT,
                Url = StaticData.CouponAPIBase + "/api/couponapi",
                Data = dto
            });
        }
    }
}
