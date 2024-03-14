using AutoMapper;
using Vegapunk.Services.CouponAPI.Models;
using Vegapunk.Services.CouponAPI.Models.Dto;

namespace Vegapunk.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
