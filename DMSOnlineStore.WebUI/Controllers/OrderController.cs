using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.WebUI.Repositories.Order;
using DMSOnlineStore.WebUI.ViewModel.OrderCreated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrder order, UserManager<ApplicationUser> userManager)
        {
            _order = order;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
         [HttpPost]
         [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateOrderViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
          await  _order.CreateOrder(model, new Guid(userId));
            return RedirectToAction("Index");
        }
    }
}
