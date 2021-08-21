using System;
using System.ComponentModel.DataAnnotations;

namespace DMSOnlineStore.WebUI.ViewModel.CardHomeViewModel
{
    public class CardHomeViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Image")]
        public byte[] ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        [Display(Name = "Tax")]
        public string Vat { get; set; }
    }
}
