using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DMSOnlineStore.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace DMSOnlineStore.Core.Models
{
   public class Order   
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public StatueType Statue { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        //public Guid UserId { get; set; }
        //public IdentityUser User { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
