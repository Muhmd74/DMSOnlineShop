using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel;
using DMSOnlineStore.WebUI.ViewModel.UomViewModel;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories.Uom
{
    public class UomServices : IUom
    {
        private readonly ApplicationDbContext _context;

        public UomServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(UomFormViewModel model)
        {
            try
            {
               await _context.UnitOfMeasures.AddAsync(new UnitOfMeasure()
                {
                    Description = model.Description,
                    Name = model.Name,
                    DateTime = DateTime.Now
                });
             await   _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Update(UomFormViewModel model)
        {
            var result = await _context.UnitOfMeasures.FirstOrDefaultAsync(d => d.Id == model.Id);
            if (result != null)
            {
                result.Description = model.Description;
                result.Name = model.Name;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteOrRestore(Guid id)
        {
            try
            {
                var result = await _context.UnitOfMeasures.FirstOrDefaultAsync(d => d.Id == id);
                if (result != null)
                {
                    result.IsDeleted = !result.IsDeleted;
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<UomFormViewModel>> GetAll()
        {
            return await _context.UnitOfMeasures
                .OrderByDescending(d=>d.DateTime)
                .Select(d => new UomFormViewModel()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                IsDeleted = d.IsDeleted
            }).ToListAsync();
            
        }

        public async Task<IEnumerable<UomFormViewModel>> Filter(string name)
        {
            return await _context.UnitOfMeasures
                .Where(d => d.Name.Contains(name))
                .Select(d => new UomFormViewModel()
                {
                    Name = d.Name,
                    Description = d.Description,
                    Id = d.Id
                }).ToListAsync();
           
        }

        public async Task<IEnumerable<UomFormViewModel>> GetAllDeleted()
        {
            return await _context.UnitOfMeasures
                .OrderByDescending(d => d.DateTime)
                .Where(d => d.IsDeleted )
                .Select(d => new UomFormViewModel()
                {
                    Name = d.Name,
                    Description = d.Description
                }).ToListAsync();
        }

        public async   Task<UomFormViewModel> Get(Guid id)
        {
            var result = await _context.UnitOfMeasures.FirstOrDefaultAsync(d => d.Id == id);
            if (result != null)
            {
                return new UomFormViewModel()
                {
                    Name = result.Name,
                    Description = result.Description
                };
            }

            return null;
        }
    }
}
