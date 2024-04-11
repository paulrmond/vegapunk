using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;
using Vegapunk.FrontEnd.Shaka.Utility;

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

        [HttpPost("OrderReadyForPickup")]
        public async Task<IActionResult> OrderReadyForPickup(int OrderHeaderId)
        {
            string userId = "1";
            OrderHeaderDto list = new OrderHeaderDto();
            ResponseDto response = await _orderService.UpdateOrderStatus(OrderHeaderId, StaticData.StatusReadyForPickup);
            if (response != null && response.IsSuccess == true)
            {
                TempData["success"] = "Order status updated.";
                return RedirectToAction(nameof(OrderDetail), new { OrderHeaderId = OrderHeaderId });
            }
            return View();
        }

        [HttpPost("CompleteOrder")]
        public async Task<IActionResult> CompleteOrder(int OrderHeaderId)
        {
            string userId = "1";
            OrderHeaderDto list = new OrderHeaderDto();
            ResponseDto response = await _orderService.UpdateOrderStatus(OrderHeaderId, StaticData.StatusCompleted);
            if (response != null && response.IsSuccess == true)
            {
                TempData["success"] = "Order status updated.";
                return RedirectToAction(nameof(OrderDetail), new { OrderHeaderId = OrderHeaderId });
            }
            return View();
        }

        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int OrderHeaderId)
        {
            string userId = "1";
            OrderHeaderDto list = new OrderHeaderDto();
            ResponseDto response = await _orderService.UpdateOrderStatus(OrderHeaderId, StaticData.StatusCancelled);
            if (response != null && response.IsSuccess == true)
            {
                TempData["success"] = "Order status updated.";
                return RedirectToAction(nameof(OrderDetail), new { OrderHeaderId = OrderHeaderId });
            }
            return View();
        }
    }
}
