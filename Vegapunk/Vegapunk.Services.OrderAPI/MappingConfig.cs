using AutoMapper;
using Vegapunk.Services.OrderAPI.Models;
using Vegapunk.Services.OrderAPI.Models.Dto;
namespace Vegapunk.Services.OrderAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderHeaderDto, CartHeaderDto>()
                .ForMember(dest=>dest.CartTotal, u=> u.MapFrom(src=>src.OrderTotal)).ReverseMap();
                config.CreateMap<CartDetailDto, OrderDetailsDto>()
                .ForMember(dest => dest.ProductName, u => u.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Amount, u => u.MapFrom(src => src.Product.Amount));

                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
