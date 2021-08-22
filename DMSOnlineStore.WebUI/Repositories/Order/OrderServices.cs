using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore;
using DMSOnlineStore.Core.Enums;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.Repositories.Order.Dtos;
using DMSOnlineStore.WebUI.ViewModel.OrderCreated;

namespace DMSOnlineStore.WebUI.Repositories.Order
{
    public class OrderServices : IOrder, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public OrderServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrder(CreateOrderViewModel model, Guid userId)
        {
            try
            {
                var result = await _context.Orders.AddAsync(new Core.Models.Order()
                {
                    
                    TotalPrice = ItemInOrder(userId).Sum(d => d.Price),
                    OrderDetails = ItemInOrder(userId),
                    UserId = userId.ToString(),
                    DueDate = model.DueDate,
                    Address = model.Address,
                    Description = model.Description,
                    RequestDate = model.RequestDate,
                    OrderDate = DateTime.Now,
                    Statue = StatueType.Request,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<OrderDetail> ItemInOrder(Guid userId)
        {
            var model = _context.OrderDetails
                .Where(d=>d.InCart)
                .Where(d => d.UserId == userId).ToList();
            foreach (var orderDetail in model)
            {
                orderDetail.InCart = false;
            }
            return model;
        }

        public void Dispose()
        {
        }
    }
}
