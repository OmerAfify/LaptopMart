using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LaptopMart.Controllers
{
    public class HomeController : Controller
    {

        private IItemService _itemService;
        public HomeController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var items = _itemService.GetAllItemsCategoriesView().Take(12).ToList();
            return View(items);
        }

      
    }
}
