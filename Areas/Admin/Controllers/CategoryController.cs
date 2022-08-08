using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Areas.Admin.Controllers
{

    [Area("admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService { get;}
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddCategory()
        {
            return View(new Category());
        } 
        
        public IActionResult EditCategory(int id)
        {
            if(id != null)
            {
                Category category = _categoryService.GetCategoryById(id);
                return View("AddCategory", category);
            }
            else
            {
                return View();
            }
           
        }



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
          
                return View("AddCategory", category);

            }
            else { 

                if(category.categoryId == 0)
                {
                    _categoryService.AddCategory(category);
                }
                else
                {
                    _categoryService.UpdateCategory(category);
                }

    
            return RedirectToAction("CategoriesList");

            }
        }
        
        public IActionResult CategoriesList()
        {
            var categories = _categoryService.GetAllCategories().ToList();
            return View(categories);
        }
        
        
        
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.RemoveCategory(id);
            return RedirectToAction("CategoriesList");
        }



    }
}
