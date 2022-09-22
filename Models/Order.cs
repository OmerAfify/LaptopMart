using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class Order
    {
      

        public int orderId { get; set; }
        public string userId { get; set; }
        public MyApplicationUser user { get; set; }

        public DateTime orderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int payementId { get; set; }
        public Payement payement { get; set; }

        public List<OrderItem> orderItems { get; set; }

        public int shippingInfoId { get; set; }
        public ShippingInfo shippingInfo { get; set; }
        public int totalOrderQty { get; set; }
        public decimal totalOrderPrice { get; set; }

        public int orderStatusId { get; set; }

        public OrderStatus orderStatus { get; set; }
     



    }
}
