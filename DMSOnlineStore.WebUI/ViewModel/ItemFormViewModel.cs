using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.ViewModel
{
    public class ItemFormViewModel
    {
        [Required,StringLength(250)]
        public string Name { get; set; }
        [ StringLength(250)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public float Discount { get; set; } 
        public decimal Vat { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "UOM")]
        public Guid UnitOfMeasureId { get; set; }
    }
}
