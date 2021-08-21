using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Enums;
using DMSOnlineStore.WebUI.Repositories.OrderDetails;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace DMSOnlineStore.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetails _order;
        private readonly IToastNotification _toastNotification;

        public OrderDetailsController(IOrderDetails order, IToastNotification toastNotification)
        {
            _order = order;
            _toastNotification = toastNotification;
        }
        [HttpGet]
         public async Task<IActionResult> Index()
        {
            var model = await _order.GetOrders();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetails(Guid id)
        {
            var model = await _order.OrderDetails(id);

            if (model != null)
            {
                return View(model);
            }

            return View(model);
        }

        public async Task<IActionResult> ChangeStatue(Guid id, StatueType statue)
        {
            var model =await _order.ChangeStatueOrder(id, statue);
            return RedirectToAction("Index");
        }
    }
}
