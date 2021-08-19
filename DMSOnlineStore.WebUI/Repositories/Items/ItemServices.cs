using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel.ItemsViewModel;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories.Items
{
    public class ItemServices : IItem,IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ItemServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ItemFormViewModel> Add(ItemFormViewModel model)
        {
            try
            {
              var resylt=  await _context.Items.AddAsync(new Item()
                {
                    Name = model.Name,
                    Created = DateTime.Now,
                    Description = model.Description,
                    Discount = (float) 10.327,
                    Price = 45,
                    Quantity = 45,
                    UnitOfMeasureId = model.UnitOfMeasureId,
                    Vat =54
                });
                await _context.SaveChangesAsync();
                return new ItemFormViewModel();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ItemFormViewModel> Update(ItemFormViewModel model)
        {
            var result = await _context.Items.FirstOrDefaultAsync(d => d.Id == model.Id);
            if (result != null)
            {
                result.Description = model.Description;
                result.Discount = model.Discount;
                result.Name = model.Name;
                result.Price = model.Price;
                result.Vat = model.Vat;
                result.UnitOfMeasureId = model.UnitOfMeasureId;
                await _context.SaveChangesAsync();
                return new ItemFormViewModel();
            }

            return null;
        }

        public async Task<bool> DeleteOrRestore(Guid id)
        {
            var result = await _context.Items.FirstOrDefaultAsync(d => d.Id == id);

            if (result != null)
            {
                result.IsDeleted = !result.IsDeleted;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ChangeActivity(Guid id)
        {
            var result = await _context.Items.FirstOrDefaultAsync(d => d.Id == id);

            if (result != null)
            {
                result.IsActive = !result.IsActive;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ItemsViewModel>> Filter(string name)
        {
            return await _context.Items.Include(d => d.UnitOfMeasure)
                .OrderByDescending(d => d.Created)
                .Where(d => d.Name.Contains(name))
                .Select(d => new ItemsViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Discount = d.Discount,
                    Quantity = d.Quantity,
                    Uom = d.UnitOfMeasure.Name,
                    Price = d.Price,
                }).ToListAsync();

        }

        public async Task<IEnumerable<ItemsViewModel>> GetAll()
        {
            return await _context.Items.Include(d => d.UnitOfMeasure)
                .OrderByDescending(d => d.Created)
                .Select(d => new ItemsViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Discount = d.Discount,
                    Quantity = d.Quantity,
                    Uom = d.UnitOfMeasure.Name,
                    Price = d.Price,
                    IsDeleted = d.IsDeleted
                }).ToListAsync();
        }



        public async Task<IEnumerable<ItemsViewModel>> GetAllDeleted()
        {
            return await _context.Items.Include(d => d.UnitOfMeasure)
                .OrderByDescending(d => d.Created)
                .Where(d => d.IsDeleted)
                .Select(d => new ItemsViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Discount = d.Discount,
                    Quantity = d.Quantity,
                    Uom = d.UnitOfMeasure.Name,
                    Price = d.Price
                }).ToListAsync();

        }

        public async Task<ItemFormViewModel> Get(Guid id)
        {
            var result = await _context.Items
                .Include(d => d.UnitOfMeasure)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (result != null)
            {
                return new ItemFormViewModel()
                {
                    Name = result.Name,
                    Description = result.Description,
                    Created = result.Created,
                    Discount = result.Discount,
                    ImageUrl = result.ImageUrl,
                    Price = result.Price,
                    Quantity = result.Quantity,
                    UomName = result.UnitOfMeasure.Name,
                    Vat = result.Vat
                };
            }

            return null;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
