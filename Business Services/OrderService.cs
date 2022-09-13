using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Business_Services
{
    public class OrderService : IOrderService
    {
        private LapShopContext _context { get; set; }
        private IOrderItemService _orderItemService { get; set; }
        private IShippingInfoService _shippingInfoService { get; set; }

        public OrderService(LapShopContext context,IOrderItemService orderItemService, IShippingInfoService shippingInfoService)
        {
            _context = context;
            _orderItemService = orderItemService;
            _shippingInfoService = shippingInfoService;
        }
        public void AddOrder(Order order) {

            _context.Tb_Orders.Add(order);
            _context.SaveChanges();

        }

        
        public void SaveUsersOrder(Order order , List<OrderItem> orderItems, ShippingInfo shippingInfo )
        {
            
                using (var transaction = _context.Database.BeginTransaction() )
                {

                try { 

                    _shippingInfoService.AddShippingInfo(shippingInfo);

                    order.shippingInfoId = shippingInfo.shippingInfoId;
                    AddOrder(order);

                    foreach (var item in orderItems) {
                        item.orderId = order.orderId;
                        _orderItemService.AddOrderItem(item);
                        }

                    transaction.Commit();

                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                    }

                }
 
        }

        public List<VwOrderDetails> GetAllCustomersVwOrders(string Email)
        {
            try {
               var orders =  _context.VwOrderDetails.Where(e => e.Email == Email).OrderByDescending(c=>c.orderDate).ToList();
               return orders;

            }catch(Exception ex) {

                return new List<VwOrderDetails>();
            }
        }


    }
}
