using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaptopMart.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IItemService _itemService;
        public ShoppingCartController(IItemService itemService)
        {
            _itemService = itemService;
        }
       
        [Authorize]
        public IActionResult Cart()
        {
            var shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };
          
            var session = HttpContext.Session.GetString("Cart");

            if (session != null)
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(session);
           
            return View(shoppingCart);
        }


        public IActionResult AddToCart(int id)
        {
            var session = HttpContext.Session.GetString("Cart");
   
            var shoppingCart = new ShoppingCart() { cartItemsList = new List<CartItem>() };

            var itemToAdd = _itemService.GetItemById(id);


            if (session != null)
            {
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(session);

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

            HttpContext.Session.SetString("Cart",  JsonConvert.SerializeObject(shoppingCart)  );

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
