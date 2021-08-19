using System;
using System.Threading.Tasks;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel.CardDetails;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories.CardDetails
{
    public class CardDetailsServices : ICardDetails
    {
        private readonly ApplicationDbContext _context;

        public CardDetailsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CardDetailsViewModel> CardDetails(Guid id)
        {
            var model = await _context.Items
                .Include(d => d.UnitOfMeasure)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                return new CardDetailsViewModel()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Discount = model.Discount,
                    Id = model.Id,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    Uom = model.UnitOfMeasure.Name,

                };
            }

            return null;
        }
    }
}
