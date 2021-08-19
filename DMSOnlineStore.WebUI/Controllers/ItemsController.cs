using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.Items;
using DMSOnlineStore.WebUI.Repositories.Uom;
using DMSOnlineStore.WebUI.ViewModel.ItemsViewModel;
using Microsoft.AspNetCore.Http;
using NToastNotify;

namespace DMSOnlineStore.WebUI.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItem _item;
        private readonly IToastNotification _toastNotification;
        private readonly IUom _uom;
        private readonly FileService.FileService _fileService;

        public ItemsController(IItem item, IToastNotification toastNotification, IUom uom,   FileService.FileService fileService)
        {
            _item = item;
            _toastNotification = toastNotification;
            _uom = uom;
            _fileService = fileService;

        }

        public async Task<IActionResult> Index()
        {
            var model = await _item.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Search(string name)
        {
            var model = await _item.Filter(name);
            return View("Index", model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var mode = await _item.DeleteOrRestore(id);
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var model = await _item.Get(id);
            return View(model);

        }

        public async Task<IActionResult> Update(Guid id)
        {
            var viewModel = await _item.Get(id);
            var model = await _item.Update(viewModel);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new ItemFormViewModel()
            {
                UnitOfMeasures = await _uom.GetAll()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Create();

            }
            var files = Request.Form.Files;
            if (files.Any())
            {
                model.ImageUrl = await _fileService.Upload(files.FirstOrDefault(), "Items");
            }
            var result = _item.Add(model);
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");

            return RedirectToAction(nameof(Index));

        }
    }
}
