using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LaptopMart.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IItemService _itemService;
        private UserManager<MyApplicationUser> _userManager;
     

        public ShoppingCartController(IItemService itemService, UserManager<MyApplicationUser> userManager)
        {
            _userManager = userManager;
            _itemService = itemService;


        }



        public ShoppingCart GetShoppingCart()
        {
            var shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };

            string state = null;

            if (User.FindFirstValue(ClaimTypes.Email) == null)
            {
                state = HttpContext.Request.Cookies["shoppingCart"];
            }
            else
            {
                state = HttpContext.Session.GetString(User.FindFirstValue(ClaimTypes.Email));
            }


            if (state != null) { 
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(state);
                return shoppingCart;
            }
            else
            {
                return null;
            }

        }


        public IActionResult Cart()
        {
            var cart = GetShoppingCart();

            if (cart == null)
            {
                return View(new ShoppingCart() { cartItemsList = new List<CartItem>() });
            }
           
            return View(cart);
        }


        public void AddToCart(int id, int? qty)
        {
            string state = null;

            if (User.FindFirstValue(ClaimTypes.Email) == null)
            {
                state = HttpContext.Request.Cookies["shoppingCart"];
            }
            else
            {
                state = HttpContext.Session.GetString(User.FindFirstValue(ClaimTypes.Email));
            }


            var shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };

            var itemToAdd = _itemService.GetItemById(id);


            if (state != null)
            {
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(state);

                var cartItem = shoppingCart.cartItemsList.Where(i => i.itemId == id).FirstOrDefault();


                if(cartItem != null)
                {
                    if (qty != null && qty <= 0) {
                        shoppingCart.cartItemsList.Remove(cartItem);
                    }
                    else
                    {
                    cartItem.totalQty =  (qty == null) ? cartItem.totalQty + 1 : (int)qty;
                    cartItem.totalPrice = cartItem.totalQty * cartItem.itemPrice;
                    }
 
                }
                else
                {
                    shoppingCart.cartItemsList.Add(this.createCartItem(itemToAdd));
                }
         
            }
            else
            {
                shoppingCart.cartItemsList.Add(this.createCartItem(itemToAdd));
            }
           
            shoppingCart.totalShoppingCartQty = shoppingCart.cartItemsList.Sum(q => q.totalQty);
            shoppingCart.totalShoppingCartPrice = shoppingCart.cartItemsList.Sum(p => p.totalPrice);


            if (User.FindFirstValue(ClaimTypes.Email) != null) { 
                HttpContext.Session.SetString(User.FindFirstValue(ClaimTypes.Email),JsonConvert.SerializeObject(shoppingCart)  );
            }
            else
            {
                HttpContext.Response.Cookies.Append("shoppingCart", JsonConvert.SerializeObject(shoppingCart));
            }

        }


        public bool RemoveFromCart(int id)
        {
            string state = null;

            if (User.FindFirstValue(ClaimTypes.Email) == null)
            {
                state = HttpContext.Request.Cookies["shoppingCart"];
            }
            else
            {
                state = HttpContext.Session.GetString(User.FindFirstValue(ClaimTypes.Email));
            }


            var itemToRemove = _itemService.GetItemById(id);

            ShoppingCart shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };

            if (state != null)
            {
                 shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(state);

                var cartItem = shoppingCart.cartItemsList.Where(i => i.itemId == id).FirstOrDefault();

                if (cartItem != null)
                {
                    shoppingCart.cartItemsList.Remove(cartItem);
                }
            }
            else
            {
                return false;
            }

            shoppingCart.totalShoppingCartQty = shoppingCart.cartItemsList.Sum(q => q.totalQty);
            shoppingCart.totalShoppingCartPrice = shoppingCart.cartItemsList.Sum(p => p.totalPrice);


            if (User.FindFirstValue(ClaimTypes.Email) != null)
            {
                HttpContext.Session.SetString(User.FindFirstValue(ClaimTypes.Email), JsonConvert.SerializeObject(shoppingCart));
            }
            else
            {
                HttpContext.Response.Cookies.Append("shoppingCart", JsonConvert.SerializeObject(shoppingCart));
            }

            return true;

        }




        private CartItem createCartItem(Item item, int qty=1)
        {
            return new CartItem()
            {
                itemId = item.itemId,
                itemName = item.itemName,
                itemPrice = item.salesPrice,
                imageName = item.imageName,
                totalPrice = item.salesPrice * qty,
                totalQty = qty
            };

        }






    }
}
