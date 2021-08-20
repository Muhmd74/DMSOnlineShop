using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.Uom;
using DMSOnlineStore.WebUI.ViewModel;
using DMSOnlineStore.WebUI.ViewModel.UomViewModel;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace DMSOnlineStore.WebUI.Controllers
{
    [Authorize]
    public class UomController : Controller
    {
        private readonly IUom _uom;
        private readonly IToastNotification _toastNotification;

        public UomController(IUom uom, IToastNotification toastNotification)
        {
            _uom = uom;
            _toastNotification = toastNotification;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            var model = await _uom.GetAll(name);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UomFormViewModel model)
        {

            if (!ModelState.IsValid)
            {

                return View(model);
            }
            await _uom.Add(model);
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteOrRestore(Guid id)
        {
            await _uom.DeleteOrRestore(id);
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id)
        {
            var viewModel = await _uom.Get(id);
            await _uom.Update(viewModel);
            return View("Create", viewModel);
        }
    }
}
