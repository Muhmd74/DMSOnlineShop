using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DMSOnlineStore.Core.Interfaces;

namespace DMSOnlineStore.Core.Models
{
   public class UnitOfMeasure :BaseEntity, IAggregateRoot
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
