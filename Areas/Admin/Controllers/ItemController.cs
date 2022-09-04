using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.BusinessServices;
using LaptopMart.Helpers;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private IItemService _itemService;
        private ICategoryService _categoryService;
        private IOsService _osService;
        private IItemTypeService _itemTypeService;
       
        public ItemController(IItemService itemService,
                              ICategoryService categoryService,
                              IOsService osService, 
                              IItemTypeService itemTypeService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _osService = osService;
            _itemTypeService = itemTypeService;
        }
        
        public IActionResult ItemsList()
        {
            var items = _itemService.GetAllItemsCategoriesView().ToList();

            return View(items);
        }
   
        public  PartialViewResult GetItemByIdPartial(int id)
        {
            var item = _itemService.GetItemById(id);
            return PartialView("_ItemModal", item);
        }

        public IActionResult AddNewItem()
        {
            Item item = new Item();
            ViewBag.categories = _categoryService.GetAllCategories().ToList();
            ViewBag.osTypes = _osService.GetAllOS().ToList();
            ViewBag.itemTypes = _itemTypeService.GettAllItemTypes().ToList();

            return View(item);
        }
        public IActionResult UpdateItem(int id)
        {
            if (id != 0)
            {

                Item item = _itemService.GetItemById(id);

                ViewBag.categories = _categoryService.GetAllCategories().ToList();
                ViewBag.osTypes = _osService.GetAllOS().ToList();
                ViewBag.itemTypes = _itemTypeService.GettAllItemTypes().ToList();
                return View("AddNewItem", item);

            }
            else
            {
                return RedirectToAction("AddNewItem");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Item item, IFormFile Files)
        {
            if (ModelState.IsValid)
            {
                if(Files != null)
                {
                    if(item.imageName != null) { 
                    UploadingFilesHelper.DeleteImage(@"wwwRoot\Uploads\Images\ItemImages\", item.imageName);
                    }

                    item.imageName = UploadingFilesHelper.UploadImage(Files, @"wwwRoot\Uploads\Images\ItemImages\").Result;
                }


                if(item.itemId == 0)
                {
                item.createdBy = "11";
                item.createdDate = DateTime.Now;

                _itemService.AddItem(item);

                }
                else
                {
                    item.updatedBy = "11";
                    item.updatedDate = DateTime.Now;

                    _itemService.UpdateItem(item);

                }

                return RedirectToAction("ItemsList");

            }
            else
            {
                return View("AddNewItem", item);
            }
    
        }

        public IActionResult DeleteItem(int id)
        {

            var itemImg = _itemService.GetItemById(id).imageName;

            if(itemImg != null) { 
             UploadingFilesHelper.DeleteImage(@"wwwRoot\Uploads\Images\ItemImages\", itemImg);
            }

            _itemService.DeleteItem(id);

            return RedirectToAction("ItemsList");
        }

        

    }
}
