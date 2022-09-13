using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class VwOrderDetails
    {
        public int orderId { get; set; }
        public string Email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int DeptNo{ get; set; }
        public int phoneNo{ get; set; }
        public DateTime orderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int totalOrderQty{ get; set; }
        public decimal totalOrderPrice{ get; set; }
        public string PayementType{ get; set; }

    }
}
