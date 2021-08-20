using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.Items;
using DMSOnlineStore.WebUI.Repositories.Uom;
using DMSOnlineStore.WebUI.ViewModel.ItemsViewModel;
using Microsoft.AspNetCore.Authorization;
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

        public ItemsController(IItem item, IToastNotification toastNotification, IUom uom, FileService.FileService fileService)
        {
            _item = item;
            _toastNotification = toastNotification;
            _uom = uom;
            _fileService = fileService;

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(string name)
        {
            var model = await _item.GetAll(name);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            ViewData["GetItem"] = name;
            var model = await _item.Filter(name);
            return View("Index", model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var mode = await _item.DeleteOrRestore(id);
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var model = await _item.Get(id);
            return View(model);

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update()
        {
            var viewModel = new ItemFormViewModel()
            {
                UnitOfMeasures = await _uom.GetAll("")
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(Guid id)
        {

            var viewModel = await _item.Get(id);
            if (viewModel!=null)
            {
                if (!ModelState.IsValid)
                {
                    await _item.Update(viewModel);
                    _toastNotification.AddSuccessToastMessage(" The operation was successfully ");

                    return RedirectToAction("Create");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            else
            {
                return Json($"this Item NorFound ");
            }
            return View("Create");

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ItemFormViewModel()
            {
                UnitOfMeasures = await _uom.GetAll("")
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ItemFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await Create();

            }
            var files = Request.Form.Files;
            if (files.Any())
            {
                model.ImageUrl = await _fileService.Upload(files.FirstOrDefault(), "Items");
            }
            var result = await _item.Add(model);
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");

            return RedirectToAction(nameof(Index));

        }
    }
}
