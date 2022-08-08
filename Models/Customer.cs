using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class Customer
    {
        public Customer()
        {
           customerItems = new HashSet<customerItem>();
        }

        public int customerId { get; set; }
        public string customerName { get; set; }
        public virtual BusinessInfo businessInfo { get; set; }
        public virtual ICollection<customerItem> customerItems { get; set; }
    }
}
