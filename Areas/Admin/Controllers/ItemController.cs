using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        public IActionResult LaptopList()
        {
            return View();
        }
        
        public IActionResult AddLaptop()
        {
            return View();
        }
    }
}
