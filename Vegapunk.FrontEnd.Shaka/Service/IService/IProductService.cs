using Vegapunk.FrontEnd.Shaka.Models;

namespace Vegapunk.FrontEnd.Shaka.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductnAsync(string productName);
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto dto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto dto);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
