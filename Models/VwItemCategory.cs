using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class VwItemCategory
    {
        public string itemName { get; set; }
        public decimal salesPrice { get; set; }
        public string categoryName { get; set; }
        public decimal purchasePrice { get; set; }
        public string imageName { get; set; }
        public int itemId { get; set; }
        public int categoryId { get; set; }
    }
}
