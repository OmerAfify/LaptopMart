using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class Category
    {
        public Category()
        {
            items = new HashSet<Item>();
        }

        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int currentState { get; set; }
        public string imageName { get; set; }
        public bool? showInHomePage { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public virtual ICollection<Item> items { get; set; }
    }
}
