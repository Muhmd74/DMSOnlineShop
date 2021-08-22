using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DMSOnlineStore.Core.Enums;

namespace DMSOnlineStore.Core.Models
{
   public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool InCart { get; set; }
        public DateTime DateTime { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
