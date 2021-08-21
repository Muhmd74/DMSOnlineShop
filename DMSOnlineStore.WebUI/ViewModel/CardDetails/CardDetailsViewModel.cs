using System;

namespace DMSOnlineStore.WebUI.ViewModel.CardDetails
{
    public class CardDetailsViewModel
    {
        public Guid Id { get; set; }
        public byte[] ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public string Uom { get; set; }
     
    }
}
