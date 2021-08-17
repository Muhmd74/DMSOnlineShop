using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.ViewModel
{
    public class CardHomeViewModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
