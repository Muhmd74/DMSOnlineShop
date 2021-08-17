using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;

namespace DMSOnlineStore.WebUI.ViewModel
{
    public class OrderDetailsOrderFormViewModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [Required,Display(Name = "UOM")]
        public Guid UnitOfMeasureId { get; set; }
        [Required,Display(Name= "Item Name")]
        public Guid ItemId { get; set; }

    }
}
