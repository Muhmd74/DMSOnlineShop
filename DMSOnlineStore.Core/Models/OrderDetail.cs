using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMSOnlineStore.Core.Models
{
   public class OrderDetail : BaseEntity
    {
       public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
