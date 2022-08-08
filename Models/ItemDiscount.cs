using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class ItemDiscount
    {
        public int itemDiscountId { get; set; }
        public decimal discountPercent { get; set; }
        public DateTime endDate { get; set; }
         public int itemId { get; set; }
        public virtual Item item { get; set; }
    }
}
