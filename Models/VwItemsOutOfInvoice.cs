using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class VwItemsOutOfInvoice
    {
        public string itemName { get; set; }
        public string categoryName { get; set; }
        public decimal? invoicePrice { get; set; }
        public decimal? purchasePrice { get; set; }
    }
}
