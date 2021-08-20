using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.CardHome;
using Microsoft.AspNetCore.Authorization;

namespace DMSOnlineStore.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ICard _card;

        public HomeController(ICard card)
        {
            _card = card;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string name)
        {
            var model =await _card.GetCards(  name);
            return View(model);
        }
    }
}
