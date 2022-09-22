using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class OrderStatus
    {
        public int orderStatusId { get; set; }
        public string orderStatusName { get; set; }
        public List<Order> orders { get; set; }
    }
}
