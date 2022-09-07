using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class CartItem
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string imageName { get; set; }
        public decimal itemPrice{ get; set; }
        public int totalQty{ get; set; }
        public decimal totalPrice{ get; set; }
    }
}
