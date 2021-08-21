using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.ViewModel.CartShipping
{
    public class CartShippingViewModel
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Tax { get; set; }
        public float Discount { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }


    }
}
