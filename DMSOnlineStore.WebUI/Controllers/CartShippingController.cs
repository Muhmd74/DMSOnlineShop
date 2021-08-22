using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AspNetCore;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.Repositories.CartShipping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using NToastNotify;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class CartShippingController : Controller
    {

        private readonly ICartShipping _cartShipping;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IToastNotification _toastNotification;

        public CartShippingController(ICartShipping cartShipping, UserManager<ApplicationUser> userManager, IToastNotification toastNotification)
        {
            _cartShipping = cartShipping;
            _userManager = userManager;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var model = await _cartShipping.CartItems(new Guid(userId));
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(Guid id)
        {

            var model = await _cartShipping.DeleteItem(id);
            _toastNotification.AddSuccessToastMessage(" Item Remove was successfully ");

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateQuantity(Guid id,int quantity)
        {

            var model = await _cartShipping.UpdateQuantity(id,quantity);
            _toastNotification.AddSuccessToastMessage(" Item Updated was successfully ");

            return RedirectToAction(nameof(Index));
        }
    }
}
