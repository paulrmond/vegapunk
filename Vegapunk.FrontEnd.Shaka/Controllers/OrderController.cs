using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;

namespace Vegapunk.FrontEnd.Shaka.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        { 
            _orderService = orderService;
        }
        public IActionResult OrderIndex()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            string userId = "1";
            IEnumerable<OrderHeaderDto> list = new List<OrderHeaderDto>();
            try
            {
                ResponseDto response = await _orderService.GetAllOrder(userId);
                if (response != null && response.IsSuccess == true)
                {
                    var asd = JsonConvert.DeserializeObject<List<OrderHeaderDto>>(Convert.ToString(response.Result));
                    list = JsonConvert.DeserializeObject<List<OrderHeaderDto>>(Convert.ToString(response.Result));
                }
            }
            catch (Exception)
            {
            }

            return Json(list);
        }

        public async Task<IActionResult> OrderDetail(int orderId)
        {
            string userId = "1";
            OrderHeaderDto list = new OrderHeaderDto();
            ResponseDto response = await _orderService.GetOrder(orderId);
            if (response != null && response.IsSuccess == true)
            {
                list = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
