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

namespace DMSOnlineStore.WebUI.Controllers
{
    public class CartShippingController : Controller
    {

        private readonly ICartShipping _cartShipping;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartShippingController(ICartShipping cartShipping, UserManager<ApplicationUser> userManager)
        {
            _cartShipping = cartShipping;
            _userManager = userManager;
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
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateQuantity(Guid id,int quantity)
        {
            var model = await _cartShipping.UpdateQuantity(id,quantity);
            return RedirectToAction(nameof(Index));
        }
    }
}
