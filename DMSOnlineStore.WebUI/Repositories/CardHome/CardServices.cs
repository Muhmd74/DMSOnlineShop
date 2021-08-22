using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel.CardHomeViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories.CardHome
{
    public class CardServices : ICard
    {
        private readonly ApplicationDbContext _context;

        public CardServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CardHomeViewModel>> GetCards(string name)
        {
            var model = await _context.Items
                .OrderByDescending(d => d.Created)
                .Where(d => d.Name.Contains(name) || name == null && d.IsDeleted == false)

                .Select(d => new CardHomeViewModel()
                {
                    Name = d.Name,
                    Description = d.Description,
                    Discount = d.Discount,
                    Id = d.Id,
                    Price = d.Price,
                    ImageUrl = d.ImageUrl
                })
                .ToListAsync();
            return model;
        }


        public async Task<bool> AddItemToCart(Guid id, Guid userId)
        {
            try
            {
                await _context.OrderDetails.AddAsync(new OrderDetail()
                {
                    InCart = true,
                    ItemId = id,
                    Price = GetItem(id).Price,
                    Quantity = 1,
                    UnitOfMeasureId = GetItem(id).UnitOfMeasureId,
                    UserId = userId

                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

            
        }
        private Item GetItem(Guid id)
        {
            return _context.Items.FirstOrDefault(d => d.Id == id);
        }
    }
}
