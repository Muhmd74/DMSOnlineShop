using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMSOnlineStore.Core.Models
{
   public class UnitOfMeasure  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
