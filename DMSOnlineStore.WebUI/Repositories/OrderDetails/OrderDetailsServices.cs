using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Enums;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.ViewModel.OrderTableViewModel;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Repositories.OrderDetails
{
    public class OrderDetailsServices : IOrderDetails

    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderTableViewModel>> GetOrders()
        {
            return await _context.Orders
                 .Include(d => d.User)
                 .OrderByDescending(d => d.OrderDate)
                 .Where(d => d.Statue != StatueType.Cart)
                 .Select(d => new OrderTableViewModel()
                 {
                     Discount = d.Discount,
                     DueDate = d.DueDate,
                     ItemCount = d.OrderDetails.Count(),
                     OrderDate = d.OrderDate,
                     Statue = d.Statue.ToString(),
                     TotalPrice = d.TotalPrice,
                     UserName =$" {d.User.FirstName} {d.User.LastName}",
                     Id = d.Id

                 }).ToListAsync();
        }

        public async Task<bool> ChangeStatueOrder(Guid id, StatueType statue)
        {
            var model = await _context.Orders.FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                model.Statue = statue;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<OrderTableDetailsViewModel> OrderDetails(Guid id)
        {
            var model = await _context.Orders
                 .Include(d => d.User)
                 .Include(d => d.OrderDetails)
                 .ThenInclude(d => d.Item)
                 .Include(d => d.OrderDetails)
                 .ThenInclude(d => d.UnitOfMeasure)
                 .FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
               return new OrderTableDetailsViewModel()
               {
                   Address = model.Address,
                   Description = model.Description,
                   Discount = model.Discount,
                   DueDate = model.DueDate,
                   OrderDate = model.OrderDate,
                   RequestDate = model.RequestDate,
                   Statue = model.Statue.ToString(),
                   TaxValue = model.TaxValue,
                   TotalPrice = model.TotalPrice,
                   UserId = new Guid(model.UserId),
                   UserName = $" {model.User.FirstName} {model.User.LastName}",
                   Items = model.OrderDetails.Select(d=>new ListOfItem()
                   {
                       Price = d.Price,
                       Quantity = d.Quantity,
                       Uom = d.Item.UnitOfMeasure.Name,
                       ItemDescription = d.Item.Description,
                       Discount = d.Item.Discount,
                       Tax = d.Item.Vat,
                       ItemName = d.Item.Name
                   }).ToList()
               };
            }

            return null;
        }
    }
}
