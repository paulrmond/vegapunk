using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

namespace Vegapunk.FrontEnd.Shaka.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartBasedOnLoggedInUser());
        }

        public async Task<CartDto> LoadCartBasedOnLoggedInUser()
        {
            var userId = "1";
            ResponseDto response = await _cartService.GetCartByUserIdAsync(userId);
            if(response != null & response.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
                return cartDto;
            }
            return new CartDto();
        }
    }
}
