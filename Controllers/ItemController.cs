using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
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
            var item = _itemService.GetItemById(id);
            return View(item);
        }
    }
}
