using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
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
        private readonly ApplicationDbContext _context;

        public ItemsController(IItem item, IToastNotification toastNotification, IUom uom, FileService.FileService fileService, ApplicationDbContext context)
        {
            _item = item;
            _toastNotification = toastNotification;
            _uom = uom;
            _fileService = fileService;
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string name)
        {
            var model = await _item.GetAll(name);
            return View(model);
        }
       
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var mode = await _item.DeleteOrRestore(id);
            if (mode)
            {
                _toastNotification.AddSuccessToastMessage(" The operation was successfully ");
                return RedirectToAction(nameof(Index));
            }
            return Json($"this Item Can't Remove ");

        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var model = await _item.Get(id);
            return View(model);

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update()
        {
            var viewModel = new ItemFormViewModel()
            {
                UnitOfMeasures = await _uom.GetAll("")
            };
            return View("EditItem",viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id)
        {

            var viewModel = await _item.Get(id);
            if (viewModel != null)
            {
                if (!ModelState.IsValid)
                {
                    await _item.Update(viewModel);
                    _toastNotification.AddSuccessToastMessage(" The operation was successfully ");

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            else
            {
                return Json($"this Item NorFound ");
            }
            return RedirectToAction("Update");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ItemFormViewModel()
            {
                UnitOfMeasures = await _uom.GetAll("")
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ItemFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await Create();

            }
            var files = Request.Form.Files;
            if (!files.Any())
            {
                await Create();
                ModelState.AddModelError("ImageUrl","Please Enter Image");
                return View(model);
            }

            var allowExtensions= new List<string>(){".jpg",".png"};
            if (!allowExtensions.Contains(Path.GetExtension(files.FirstOrDefault().FileName).ToLower()))
            {
                await Create();
                ModelState.AddModelError("ImageUrl", "only .jpg and .png");
                return View(model);
            }
            using var dataStream= new MemoryStream();
            await files.FirstOrDefault().CopyToAsync(dataStream);
            var dataModel= new Item()
            {
                Name = model.Name,
                Price = model.Price,
                Created = DateTime.Now,
                Description = model.Description,
                Discount = model.Discount,
                Quantity = model.Quantity,
                UnitOfMeasureId = model.UnitOfMeasureId,
                Vat = model.Vat,
                ImageUrl = dataStream.ToArray()
            };
            await _context.Items.AddAsync(dataModel);
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage(" The operation was successfully ");

            return RedirectToAction(nameof(Index));

        }
    }
}
