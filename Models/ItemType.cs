using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            items = new HashSet<Item>();
        }

        public int itemTypeId { get; set; }
        public string itemTypeName { get; set; }
        public string imageName { get; set; }
        public int currentState { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string updatedBy { get; set; }

        public virtual ICollection<Item> items { get; set; }
    }
}
