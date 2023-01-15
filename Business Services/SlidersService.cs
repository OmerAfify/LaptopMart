using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopMart.Business_Services
{
    public class SlidersService : ISlidersService
    {

            private LapShopContext _context { get; set; }
            public SlidersService (LapShopContext context)
            {
                _context = context;
            }


            public IEnumerable<slider> GetAllSliders()
            {
                try
                {
                    var Sliders = _context.TbSliders;
                    return Sliders;

                }
                catch (Exception ex)
                {

                    return new List<slider>();
                }
            }

            public slider GetSliderById(int id)
            {
                try
                {
                    var Slider = _context.TbSliders.Where(c => c.sliderId == id).FirstOrDefault();
                    return Slider;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }

            public void AddSlider(slider Slider)
            {
                try
                {
                    _context.TbSliders.Add(Slider);
                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    return;
                }
            }

            public void UpdateSlider(slider Slider)
            {

                try
                {
                    _context.Entry(Slider).State = EntityState.Modified;


                    if (Slider.imageName == null)
                        Slider.imageName = "";

                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            public void DeleteSlider(int id)
            {

                try
                {
                    var SliderToRemove = GetSliderById(id);
                    _context.TbSliders.Attach(SliderToRemove);
                    _context.TbSliders.Remove(SliderToRemove);

                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

    
    }
}
