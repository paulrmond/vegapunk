using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

namespace Vegapunk.FrontEnd.Shaka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        public HomeController(ILogger<HomeController> logger, IProductService _productService, ICartService cartService)
        {
            _logger = logger;
            this._productService = _productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
			List<ProductDto>? list = new();
			ResponseDto? response = await _productService.GetAllProductAsync();
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

        public async Task<IActionResult> ProductDetails(int productId)
        {
            ProductDto? dto = new();
            ResponseDto? response = await _productService.GetProductByIdAsync(productId);
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
        [ActionName("ProductDetails")]
        public async Task<IActionResult> ProductDetails(ProductDto productDto)
        {
            
            CartDto cartDto = new CartDto()
            {
                CartHeader = new CartHeaderDto()
                {
                    UserId = "1"
                }
            };

            CartDetailDto cartDetals = new CartDetailDto()
            {
                Count = (int)productDto.Count,
                ProductId = productDto.ProductId,
            };

            List<CartDetailDto> cartDetailDtos = new() { cartDetals };
            cartDto.CartDetails = cartDetailDtos;

            ResponseDto? response = await _cartService.UpsertCartAsync(cartDto);

            
            if (response != null & response.IsSuccess)
            {
                TempData["success"] = "Item added to cart";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(productDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
