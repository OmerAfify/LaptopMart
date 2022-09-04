using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Helpers;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Http;
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

        public IActionResult CategoriesList()
        {
            var categories = _categoryService.GetAllCategories().AsEnumerable()
                 .OrderByDescending(r => r.createdDate).ToList();

            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View(new Category());
        } 
  
        public IActionResult EditCategory(int id)
        {
            if(id != 0)
            {
                Category category = _categoryService.GetCategoryById(id);
                return View("AddCategory", category);
            }
            else
            {
                return View("AddCategory");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult SaveCategory(Category category, IFormFile File)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory", category);
            }
            else {

                if (File != null)
                {
                    if (category.imageName != null)
                    {
                        UploadingFilesHelper.DeleteImage(@"wwwRoot\Uploads\Images\CategoryImages\", category.imageName);
                    }

                    category.imageName = UploadingFilesHelper.UploadImage(File, @"wwwRoot\Uploads\Images\CategoryImages\").Result;
                }


                if (category.categoryId == 0)
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

        public IActionResult DeleteCategory(int id)
        {

            var catImg = _categoryService.GetCategoryById(id).imageName;

            if (catImg != null)
            {
              UploadingFilesHelper.DeleteImage(@"wwwRoot\Uploads\Images\CategoryImages\", catImg);
            }

            _categoryService.DeleteCategory(id);

            return RedirectToAction("CategoriesList");
        }


    }
}
