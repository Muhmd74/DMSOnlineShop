using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DMSOnlineStore.Core.Enums;
using DMSOnlineStore.Core.Interfaces;

namespace DMSOnlineStore.Core.Models
{
   public class Order : BaseEntity , IAggregateRoot
    {
    
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public StatueType Statue { get; set; } 
        public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
