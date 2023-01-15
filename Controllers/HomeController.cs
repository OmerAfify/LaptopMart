using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
        private ISlidersService _slidersService;
        public HomeController(IItemService itemService, ISlidersService slidersService)
        {
            _itemService = itemService;
            _slidersService = slidersService;

        }

        public IActionResult Index()
        {
            var items = _itemService.GetAllItems().Take(12).ToList();
            ViewBag.user = User.FindFirstValue(ClaimTypes.Email);
            ViewBag.sliders = _slidersService.GetAllSliders();
            return View(items);
        }

      
    }
}
