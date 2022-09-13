using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopMart.Business_Services
{
    public class OrderItemService: IOrderItemService
    {

        private LapShopContext _context { get; set; }
        public OrderItemService(LapShopContext context)
        {
            _context = context;
        }
        public void AddOrderItem(OrderItem orderItem)
        {

            _context.Tb_OrderItem.Add(orderItem);
            _context.SaveChanges();

        }
        
        public List<OrderItem> GetAllOrderItemsOfOrder(int orderId)
        {
            var orderedItems = _context.Tb_OrderItem.Where(o=>o.orderId == orderId).Include(i => i.item).ToList();
            return orderedItems;

        }


    }
}
