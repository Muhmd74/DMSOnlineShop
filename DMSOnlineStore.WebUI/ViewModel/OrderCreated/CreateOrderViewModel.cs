using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.Order.Dtos;

namespace DMSOnlineStore.WebUI.ViewModel.OrderCreated
{
    public class CreateOrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
         public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderItems> Items { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

    public class OrderItems
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public Guid OrderId { get; set; }
        public Core.Models.Order Order { get; set; }
        public Guid ItemId { get; set; }
    }
}
