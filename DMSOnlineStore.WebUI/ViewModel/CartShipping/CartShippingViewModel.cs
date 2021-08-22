using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.ViewModel.CartShipping
{
    public class CartShippingViewModel
    {
        public Guid ItemId { get; set; }
        public Guid OrderDetailsId { get; set; }
        [Display(Name = "Unit Of Measure")]
        public string Uom { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Tax { get; set; }
        public float Discount { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
