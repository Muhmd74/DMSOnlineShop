//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AspNetCore;
//using DMSOnlineStore.Core.Enums;
//using DMSOnlineStore.Core.Models;
//using DMSOnlineStore.Infrastructure.Data.Tools;
//using DMSOnlineStore.WebUI.Repositories.Order.Dtos;

//namespace DMSOnlineStore.WebUI.Repositories.Order
//{
//    public class OrderServices : IOrder, IDisposable
//    {
//        private readonly ApplicationDbContext _context;

//        public OrderServices(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        //public async Task<bool> CreateOrder(OrderRequest model)
//        //{
//        //    try
//        //    {
//        //        await _context.Orders.AddAsync(new Core.Models.Order()
//        //        {
//        //            Discount = model.Discount,
//        //            DueDate = model.DueDate,
//        //            OrderDate = model.OrderDate,
//        //            RequestDate = model.RequestDate,
//        //            Statue = StatueType.Cart,
//        //            Tax = model.Tax,
//        //            TaxValue = model.TaxValue,
//        //            UserId = model.UserId,
//        //            TotalPrice = model.TotalPrice,
//        //            OrderDetails = await OrderDetails(model.Items),
//        //        });
//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}

//        public async Task<bool> AddToCard(OrderItems model)
//        {
//            var result = await _context.OrderDetails.AddAsync(new OrderDetail()
//            {
//               Price = model.Price,
//               ItemId = model.ItemId,
//                Order = _context.Orders.Add(new Core.Models.Order())
//            });
//        }

//        //private async Task<IEnumerable<OrderDetail>> OrderDetails(IEnumerable<OrderItems> modelItems)
//        //{

//        //    foreach (var item in modelItems)
//        //    {
//        //        var result = await _context.OrderDetails.AddAsync(new OrderDetail()
//        //        {
//        //            Price = item.Price,
//        //            ItemId = item.ItemId,
//        //            OrderId = item.OrderId,
//        //            Quantity = item.Quantity,
//        //            UnitOfMeasureId = item.UnitOfMeasureId
//        //        });

//        //    }
//        //    await _context.SaveChangesAsync();
//        //    return (IEnumerable<OrderDetail>)modelItems.Select(d => new OrderItems()
//        //    {
//        //        Price = d.Price,
//        //        OrderId = d.OrderId,
//        //        ItemId = d.ItemId,
//        //        Id = d.Id
//        //    }).ToList();
//        //}



//        public void Dispose()
//        {
//        }
//    }
//}
