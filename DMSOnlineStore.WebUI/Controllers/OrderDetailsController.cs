using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.OrderDetails;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetails _order;

        public OrderDetailsController(IOrderDetails order)
        {
            _order = order;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _order.GetOrders();
       
            return View(model);
        }

        public async Task<IActionResult> OrderDetails(Guid id)
        {
            var model =await _order.OrderDetails(id);
            if (model != null)
            {
                return View(model);
            }

            return View(model);
        }

        public IActionResult ChangeStatue(Guid id , int statue )
        {
            throw new NotImplementedException();
        }
    }
}
