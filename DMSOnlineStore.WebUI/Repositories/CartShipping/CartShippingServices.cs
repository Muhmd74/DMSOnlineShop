using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel.CartShipping;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories.CartShipping
{
    public class CartShippingServices : ICartShipping, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public CartShippingServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartShippingViewModel>> CartItems(Guid userId)
        {
            var model = await _context.OrderDetails.Select(d => new CartShippingViewModel()
            {
                Name = d.Item.Name,
                Discount = d.Item.Discount,
                Quantity = d.Quantity,
                Image = d.Item.ImageUrl,
                ItemId = d.ItemId,
                Tax = d.Item.Vat,
                Price = d.Item.Price
            }).ToListAsync();
            if (model.Any())
            {
                return model;
            }

            return null;
        }

        public async Task<bool> UpdateQuantity(Guid orderDetailsId, int quantity)
        {
            var result = await _context.OrderDetails.FirstOrDefaultAsync(d => d.Id == orderDetailsId);
            if (result != null)
            {
                result.Quantity = quantity;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteItem(Guid orderDetailsId)
        {
            var result = await _context.OrderDetails.FirstOrDefaultAsync(d => d.Id == orderDetailsId);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
