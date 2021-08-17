using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Enums;

namespace DMSOnlineStore.WebUI.ViewModel
{
    public class OrderFormViewModel
    {
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }
        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        public StatueType Statue { get; set; }
        public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderDetailsOrderFormViewModel> OrderDetailsOrder { get; set; }
    }
}
