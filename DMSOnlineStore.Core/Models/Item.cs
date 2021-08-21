using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMSOnlineStore.Core.Models
{
   public class Item 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public decimal Vat { get; set; }
        public byte[] ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
