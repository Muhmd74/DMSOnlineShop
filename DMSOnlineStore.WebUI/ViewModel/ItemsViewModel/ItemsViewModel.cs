using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.ViewModel.ItemsViewModel
{
    public class ItemsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public string Uom { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
