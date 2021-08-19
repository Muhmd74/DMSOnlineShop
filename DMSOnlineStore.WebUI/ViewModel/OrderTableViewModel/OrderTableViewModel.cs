using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Enums;

namespace DMSOnlineStore.WebUI.ViewModel.OrderTableViewModel
{
    public class OrderTableViewModel
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Statue { get; set; }
        public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public int ItemCount { get; set; }

        public decimal Discount { get; set; }
        [Display(Name = "Total Price")]

        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Customer Name")]
        public string UserName { get; set; }

    }
}
