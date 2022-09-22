using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
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

        
        public int SaveUsersOrder(Order order , List<OrderItem> orderItems, ShippingInfo shippingInfo )
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

                    return order.orderId;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                    return 0;
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


        public void UpdateOrderStatus(Order order) {


            var jobId = BackgroundJob.Schedule(() => setToShipped(order), TimeSpan.FromMinutes(1) );
            var jobId2 = BackgroundJob.Schedule(() => setToDelivered(order), TimeSpan.FromMinutes(2) );


                    
        }


        public void setToShipped(Order order)
        {
            var TheNeworder = _context.Tb_Orders.Where(o => o.orderId == order.orderId).FirstOrDefault();
            TheNeworder.orderStatusId = 2;
            _context.SaveChanges();
        } 
        
        public void setToDelivered(Order order)
        {
            var TheNeworder = _context.Tb_Orders.Where(o => o.orderId == order.orderId).FirstOrDefault();
            TheNeworder.orderStatusId = 3;
            _context.SaveChanges();
        }


    }
}
