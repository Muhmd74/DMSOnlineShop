using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.WebUI.Repositories.CardHome;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICard _card;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IToastNotification _toastNotification;
        public HomeController(ICard card, UserManager<ApplicationUser> userManager, IToastNotification toastNotification)
        {
            _card = card;
            _userManager = userManager;
            _toastNotification = toastNotification;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string name)
        {
            var model = await _card.GetCards(name);
            return View(model);
        }
       
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(Guid id)
        {
            var userId =  _userManager.GetUserId(HttpContext.User);

            var model = await _card.AddItemToCart(id,new Guid(userId));
            _toastNotification.AddSuccessToastMessage(" add to cart was successfully ");

            return RedirectToAction(nameof(Index));
        }
    }
}
