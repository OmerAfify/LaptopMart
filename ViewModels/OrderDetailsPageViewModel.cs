using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.ViewModels
{
    public class OrderDetailsPageViewModel
    {
        public VwOrderDetails order { get; set; }
        public List<OrderItem> orderedItems { get; set; }
    }
}
