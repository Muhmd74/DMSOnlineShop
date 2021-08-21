using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class CartShippingController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
