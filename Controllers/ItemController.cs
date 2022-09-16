using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Controllers
{
    public class ItemController : Controller
    {
        IItemService _itemService;
        public ItemController( IItemService itemService) {

            _itemService = itemService;
        }

        public IActionResult ItemDetails(int id)
        {
            var itemDetailsVm = new ItemDetailsPageViewModel()
            {
                itemDetails = _itemService.GetItemView(id),
                recomendedProducts = _itemService.GetRecomendedItems(id).Take(6).ToList()

            };
           return View(itemDetailsVm);
        }

        public IActionResult Shop()
        {
            return View();
        }

        public PartialViewResult GetProductBox2ByIdPartial(int id)
        {
            var item = _itemService.GetItemById(id);
            return PartialView("_ProductBox2", item);
        }


    }
}
