using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

namespace Vegapunk.FrontEnd.Shaka.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;   
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();
            ResponseDto? response = await _ProductService.GetAllProductAsync();
            if (response != null & response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

		public async Task<IActionResult> ProductCreate()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto ProductDto)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _ProductService.CreateProductAsync(ProductDto);
                if(response != null & response.IsSuccess)
                {
                    TempData["success"] = "Product created";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response.Message;
                }
            }
            return View(ProductDto);
        }

        public async Task<IActionResult> ProductDelete(int ProductId)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ProductService.DeleteProductAsync(ProductId);

                if(response != null & !response.IsSuccess)
                    TempData["error"] = response.Message;
                else if (response != null & response.IsSuccess)
                {
                    TempData["success"] = "Product deleted";
                }
            }
            return RedirectToAction(nameof(ProductIndex));
        }

        public async Task<IActionResult> ProductEdit(int ProductId)
        {
            ProductDto? dto = new();
            ResponseDto? response = await _ProductService.GetProductByIdAsync(ProductId);
            if (response != null & response.IsSuccess)
            {
                dto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ProductService.UpdateProductAsync(dto);

                if (response != null & !response.IsSuccess)
                    TempData["error"] = response.Message;
                else if (response != null & response.IsSuccess)
                {
                    TempData["success"] = "Product updated";
                }
            }
            return RedirectToAction(nameof(ProductIndex));
        }
    }
}
