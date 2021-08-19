using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.CardHome;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICard _card;

        public HomeController(ICard card)
        {
            _card = card;
        }

        public async Task<IActionResult> Index(string name)
        {
            var model =await _card.GetCards(  name);
            return View(model);
        }
    }
}
