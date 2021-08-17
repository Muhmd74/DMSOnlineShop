using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DMSOnlineStore.Core.Interfaces;

namespace DMSOnlineStore.Core.Models
{
   public class Item : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public decimal Vat { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
