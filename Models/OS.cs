using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class OS
    {
        public OS()
        {
           items = new HashSet<Item>();
        }

        public int osId { get; set; }
        public string osName { get; set; }
        public string imageName { get; set; }
        public bool showInHomePage { get; set; }
        public int currentState { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string updatedBy { get; set; }

        public virtual ICollection<Item> items { get; set; }
    }
}
