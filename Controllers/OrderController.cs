using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hangfire;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using LaptopMart.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaptopMart.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;
        private IPayementService _payementService;
        public OrderController(IOrderService orderService, IOrderItemService orderItemService, IPayementService payementService )
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _payementService = payementService;
        }


        public IActionResult Checkout()
        {
            var state = HttpContext.Session.GetString(User.FindFirstValue(ClaimTypes.Email));
            var cookie = HttpContext.Request.Cookies["shoppingCart"];

            var shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };


            if (state == null) {
                HttpContext.Session.SetString(User.FindFirstValue(ClaimTypes.Email), JsonConvert.SerializeObject(shoppingCart));
            }
            else
            {
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(state);
            }


    
            if (cookie != null)
            {
                var cookieShoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(cookie);

                if (cookieShoppingCart.cartItemsList != null || cookieShoppingCart.cartItemsList.Count != 0)
                {
                    shoppingCart.totalShoppingCartPrice += cookieShoppingCart.totalShoppingCartPrice;
                    shoppingCart.totalShoppingCartQty += cookieShoppingCart.totalShoppingCartQty;
                    shoppingCart.cartItemsList.AddRange(cookieShoppingCart.cartItemsList);

                    HttpContext.Session.SetString(User.FindFirstValue(ClaimTypes.Email), JsonConvert.SerializeObject(shoppingCart));

                }

                Response.Cookies.Delete("shoppingCart");
              

            }

            if (shoppingCart.cartItemsList == null || shoppingCart.cartItemsList.Count == 0)
                return Redirect("~/");



            var checkoutVm = new CheckoutPageViewModel() {

                payementTypes = _payementService.GetAllPayments().ToList(),
                shoppingCart = shoppingCart,
                shippingInfo = new ShippingInfo() { userId= User.FindFirstValue(ClaimTypes.NameIdentifier) }
        };

            return View(checkoutVm);
        }


        [HttpPost]
        public IActionResult SaveOrder(CheckoutPageViewModel checkoutPageViewModel)
        {
            var state = HttpContext.Session.GetString(User.FindFirstValue(ClaimTypes.Email));

            ShoppingCart shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(state);

            if (state == null || shoppingCart.cartItemsList == null )
                return Redirect("~/");


            if (ModelState.IsValid) {

            try {

                    Order order = new Order()
                    {
                        userId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        orderDate = DateTime.Now,
                        orderStatusId = 1,
                        DeliveryDate = DateTime.Now.AddDays(5),
                        payementId = checkoutPageViewModel.payementId,
                        shippingInfoId = checkoutPageViewModel.shippingInfo.shippingInfoId,
                        totalOrderQty = shoppingCart.totalShoppingCartQty,
                        totalOrderPrice = shoppingCart.totalShoppingCartPrice

                };


                    List<OrderItem> orderItemsList = new List<OrderItem>();

                    foreach (var itemInCart in shoppingCart.cartItemsList)
                    {
                        OrderItem orderItem = new OrderItem()
                        {
                            itemId = itemInCart.itemId,
                            orderId = order.orderId,
                            itemImage = itemInCart.imageName,
                            totalPrice = itemInCart.totalPrice,
                            totalQty = itemInCart.totalQty

                        };

                        orderItemsList.Add(orderItem);
            
                    }

                   _orderService.SaveUsersOrder(order, orderItemsList, checkoutPageViewModel.shippingInfo);

                    _orderService.UpdateOrderStatus(order);
                    HttpContext.Session.Remove(User.FindFirstValue(ClaimTypes.Email));

                    return RedirectToAction("OrderSuccess", new { orderId=order.orderId} );
               }         
                catch(Exception ex)
                {
                     return Redirect("~/");
                }


            } else {

                checkoutPageViewModel.shoppingCart = shoppingCart;
                return View("Checkout", checkoutPageViewModel);
            }
        }

        public IActionResult OrderSuccess(int orderId)
        {
            ViewBag.orderId = orderId;
            return View();
        }
        

        //gets all orders of a user with each ones details.
        public IActionResult OrderDetails()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            if ( string.IsNullOrEmpty(Email))
            {
                return Redirect("/User/Login");
            }

            var orders = _orderService.GetAllCustomersVwOrders(Email);


            var ordersWithDetails = new List<OrderDetailsPageViewModel>();

            foreach(var order in orders)
            {
                ordersWithDetails.Add( new OrderDetailsPageViewModel()
                {
                    order = order,
                    orderedItems = _orderItemService.GetAllOrderItemsOfOrder(order.orderId)

                });

            }
       

            return View(ordersWithDetails);
        }



    }
}
