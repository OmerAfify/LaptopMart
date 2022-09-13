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



        public IActionResult Cart()
        {
            var shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };

            string state = null;

            if (User.FindFirstValue(ClaimTypes.Email) == null)
            {
                state = HttpContext.Request.Cookies["shoppingCart"];
            }
            else { 
                state = HttpContext.Session.GetString(User.FindFirstValue(ClaimTypes.Email));
            }

          
            if (state != null)
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(state);
           
            return View(shoppingCart);
        }


        public IActionResult AddToCart(int id)
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
                    cartItem.totalQty++;
                    cartItem.totalPrice = cartItem.totalQty * cartItem.itemPrice;
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

            return RedirectToAction("Cart");

        }


        private CartItem createCartItem(Item item)
        {
            return new CartItem()
            {
                itemId = item.itemId,
                itemName = item.itemName,
                itemPrice = item.salesPrice,
                imageName = item.imageName,
                totalPrice = item.salesPrice,
                totalQty = 1
            };

        }






    }
}
