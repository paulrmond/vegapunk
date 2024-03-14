using AutoMapper;
using Vegapunk.Services.ProductAPI.Models;
using Vegapunk.Services.ProductAPI.Models.Dto;

namespace Vegapunk.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
