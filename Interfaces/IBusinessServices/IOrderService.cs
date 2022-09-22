using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface IOrderService
    {
        public void AddOrder(Order order);
        public int SaveUsersOrder(Order order, List<OrderItem> orderItems, ShippingInfo shippingInfo);
        public void UpdateOrderStatus(Order order);
        public List<VwOrderDetails> GetAllCustomersVwOrders(string Email);




    }
}
