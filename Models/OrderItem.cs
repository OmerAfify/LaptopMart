using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class OrderItem 
    {
        public int orderId { get; set; }
        public Order order { get; set; }

        public int itemId { get; set; }
        public Item item { get; set; }

        public int totalQty { get; set; }
        public decimal totalPrice { get; set; }


    }
}
