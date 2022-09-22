using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.ViewModels
{
    public class CheckoutPageViewModel
    {
        public List<Payement> payementTypes { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public ShippingInfo shippingInfo { get; set; }
        public int payementId { get; set; }
    }
}
