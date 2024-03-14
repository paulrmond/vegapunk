using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

using Vegapunk.FrontEnd.Shaka.Utility;

namespace Vegapunk.FrontEnd.Shaka.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto?> CreateProductAsync(ProductDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.ProductAPIBase + "/api/Productapi",
                Data = dto
            });
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.DELETE,
                Url = StaticData.ProductAPIBase + "/api/Productapi/" + id
            });
        }

        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.ProductAPIBase + "/api/Productapi"
            });
        }

        public async Task<ResponseDto?> GetProductAsync(string ProductCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.ProductAPIBase + "/api/Productapi/GetByCode/" + ProductCode
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.GET,
                Url = StaticData.ProductAPIBase + "/api/Productapi/" + id
            });
        }

        public Task<ResponseDto?> GetProductnAsync(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticData.ApiType.PUT,
                Url = StaticData.ProductAPIBase + "/api/Productapi",
                Data = dto
            });
        }
    }
}
