using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOnlineStore.WebUI.ViewModel.OrderTableViewModel
{
    public class OrderTableDetailsViewModel
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Statue { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<ListOfItem> Items { get; set; }
    }

    public class ListOfItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Uom { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public float Discount { get; set; }
        public decimal Tax { get; set; }



       
    }
}
