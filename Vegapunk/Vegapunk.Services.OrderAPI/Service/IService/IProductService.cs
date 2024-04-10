using Vegapunk.Services.OrderAPI.Models.Dto;

namespace Vegapunk.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
    }
}
