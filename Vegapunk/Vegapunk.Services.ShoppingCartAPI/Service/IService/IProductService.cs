using Vegapunk.Services.ShoppingCartAPI.Models.Dto;

namespace Vegapunk.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
    }
}
