using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface ISlidersService
    {
        public IEnumerable<slider> GetAllSliders();
        public slider GetSliderById(int id);
        public void UpdateSlider(slider slider);
        public void AddSlider(slider slider);
        public void DeleteSlider(int id);
    }
}
