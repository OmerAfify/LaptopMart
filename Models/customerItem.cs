using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class customerItem
    {
        public int itemId { get; set; }
        public int customerId { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Item item { get; set; }
    }
}
