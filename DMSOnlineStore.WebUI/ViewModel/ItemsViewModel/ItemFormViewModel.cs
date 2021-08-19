using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.WebUI.ViewModel.UomViewModel;
using Microsoft.AspNetCore.Http;

namespace DMSOnlineStore.WebUI.ViewModel.ItemsViewModel
{
    public class ItemFormViewModel
    {
        public Guid Id { get; set; }
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
        [Display(Name = "Tax")]
        public decimal Vat { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

          [Display(Name = "UOM")]
        public Guid UnitOfMeasureId { get; set; }
        public IEnumerable<UomFormViewModel> UnitOfMeasures { get; set; }

        [Display(Name = "Name Uom")]
        public string UomName { get; set; }
    }
}
