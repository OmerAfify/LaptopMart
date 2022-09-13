using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface IOrderItemService
    {
        public void AddOrderItem(OrderItem orderItem);

        public List<OrderItem> GetAllOrderItemsOfOrder(int orderId);
    }
}
