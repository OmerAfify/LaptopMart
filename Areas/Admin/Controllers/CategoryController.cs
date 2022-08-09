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

        private UploadingFilesHelper _helper = new UploadingFilesHelper();
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CategoriesList()
        {
            var categories = _categoryService.GetAllCategories().ToList();
            return View(categories);
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
        public async Task<IActionResult> SaveCategory(Category category, IFormFile File)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory", category);
            }
            else {


                if(File != null)
                {
                  

                        if (category.imageName != null)
                        {
                            _helper.DeleteImage(@"wwwRoot\Uploads\Images\CategoryImages\", category.imageName);  
                        }

                    var imageName = await _helper.UploadImage(File, @"wwwRoot\Uploads\Images\CategoryImages");
                    category.imageName = imageName;
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
           
            var img = _categoryService.GetCategoryById(id).imageName;
            if (img != null)
            {
              _helper.DeleteImage(@"wwwRoot\Uploads\Images\CategoryImages\",img);
            }

            _categoryService.RemoveCategory(id);

            return RedirectToAction("CategoriesList");
        }



    }
}
