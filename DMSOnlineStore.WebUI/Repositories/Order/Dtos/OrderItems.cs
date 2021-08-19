using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;

namespace DMSOnlineStore.WebUI.Repositories.Order.Dtos
{
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
