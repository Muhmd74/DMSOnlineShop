using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Enums;
using DMSOnlineStore.Core.Models;

namespace DMSOnlineStore.WebUI.Repositories.Order.Dtos
{
    public class OrderRequest
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public StatueType Statue { get; set; }
        public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
 
        public IEnumerable<OrderItems> Items { get; set; }
    }
}
