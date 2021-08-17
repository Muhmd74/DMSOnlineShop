using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Interfaces;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories
{
    public class EfRepository<TModel> : IAsyncRepository<TModel> where TModel : BaseEntity
    {
        private readonly ApplicationDbContext _context;
         public EfRepository(ApplicationDbContext context, DbSet<TModel> entity)
        {
            _context = context;
         }

        public async Task<TModel> GetById(Guid id)
        {
            var model = await _context.Set<TModel>().FirstOrDefaultAsync(d => d.Id == id);
            return model;
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            var model = await _context.Set<TModel>().ToListAsync();
            if (model.Any())
            {
                return model;
            }

            return null;
        }

        public async Task<TModel> Add(TModel model)
        {

            try
            {
                await _context.Set<TModel>().AddAsync(model);

                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
      
        }

        public async Task<bool> Update(TModel model)
        {
            try
            {
                _context.Set<TModel>().Update(model);
             //   _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var model=await _context.Set<TModel>().FirstOrDefaultAsync(d=>d.Id==id);
            if (model!=null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
