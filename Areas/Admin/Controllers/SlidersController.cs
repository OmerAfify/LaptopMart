using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.BusinessServices;
using LaptopMart.Helpers;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SlidersController : Controller
    {
        private ISlidersService _sliderService;
      
        public SlidersController(ISlidersService slidersService)
        {
            _sliderService = slidersService;
        }

        public IActionResult SlidersList()
        {
            var sliders = _sliderService.GetAllSliders().ToList();

            return View(sliders);
        }


        public IActionResult AddNewSlider()
        {
            slider slider = new slider();
            return View(slider);
        }

        public IActionResult UpdateSlider(int id)
        {
            if (id != 0)
            {

                slider slider= _sliderService.GetSliderById(id);

                  return View("AddNewSlider", slider);

            }
            else
            {
                return RedirectToAction("AddNewSlider");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(slider slider, IFormFile Files)
        {
            if (ModelState.IsValid)
            {
                if (Files != null)
                {
                    if (slider.imageName != null)
                    {
                        UploadingFilesHelper.DeleteImage(@"wwwRoot\Uploads\Images\SlidersImages\", slider.imageName);
                    }

                    slider.imageName = UploadingFilesHelper.UploadImage(Files, @"wwwRoot\Uploads\Images\SlidersImages\").Result;
                }


                if (slider.sliderId == 0)
                {
 
                    _sliderService.AddSlider(slider);

                }
                else
                {

                    _sliderService.UpdateSlider(slider);

                }

                return RedirectToAction("SlidersList");

            }
            else
            {
                return View("AddNewSlider", slider);
            }

        }

        public IActionResult DeleteSlider(int id)
        {

            var sliderImg = _sliderService.GetSliderById(id).imageName;

            if (sliderImg != null)
            {
                UploadingFilesHelper.DeleteImage(@"wwwRoot\Uploads\Images\SlidersImages\", sliderImg);
            }

            _sliderService.DeleteSlider(id);

            return RedirectToAction("SlidersList");
        }



    }
}
