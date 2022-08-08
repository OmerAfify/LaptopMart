using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class ItemImage
    {
        public int imageId { get; set; }
        public string imageName { get; set; }
        public int itemId { get; set; }
        public virtual Item item { get; set; }
    }
}
