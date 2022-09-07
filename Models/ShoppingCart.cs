using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class ShoppingCart
    {
        public int shoppingCartId { get; set; }
        public List<CartItem> cartItemsList { get; set; }
        public int totalShoppingCartQty { get; set; }
        public decimal  totalShoppingCartPrice { get; set; }
    }
}
