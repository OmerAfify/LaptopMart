using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class BusinessInfo
    {
        public int businessInfoId { get; set; }
        public string businessCardNumber { get; set; }
        public string officePhone { get; set; }
        public decimal budget { get; set; }
        public int customerId { get; set; }
        public virtual Customer cutomer { get; set; }
    }
}
