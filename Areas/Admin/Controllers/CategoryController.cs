using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Areas.Admin.Controllers
{

    [Area("admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddCategory()
        {
            return View();
        }
        
        public IActionResult CategoriesList()
        {

            var context = new LapShopContext();

            var categories = context.TbCategories.ToList();

            return View(categories);
        }
    }
}
