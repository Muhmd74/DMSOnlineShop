using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel.CardHomeViewModel;
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
            return await _context.Items
                .OrderByDescending(d => d.Created)
                .Where(d => d.Name.Contains(name) || name==null   && d.IsDeleted == false )

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
        }

       
    }
}
