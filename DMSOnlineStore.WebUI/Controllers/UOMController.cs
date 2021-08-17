using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Interfaces;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.WebUI.ViewModel;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class UomController : Controller
    {
        private readonly IAsyncRepository<UnitOfMeasure> _repository;

        public UomController(IAsyncRepository<UnitOfMeasure> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
           var model=await _repository.GetAll();
            return View(model);
        }
    }
}
