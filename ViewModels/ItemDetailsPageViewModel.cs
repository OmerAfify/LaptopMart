using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.ViewModels
{
    public class ItemDetailsPageViewModel
    {
        public VwItem itemDetails { get; set; }
        public List<Item> recomendedProducts { get; set; }

    }
}
