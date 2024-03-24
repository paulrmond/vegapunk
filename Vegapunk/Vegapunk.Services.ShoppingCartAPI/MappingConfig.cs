using AutoMapper;
using Vegapunk.Services.ShoppingCartAPI.Models;
using Vegapunk.Services.ShoppingCartAPI.Models.Dto;

namespace Vegapunk.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetail, CartDetailDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
