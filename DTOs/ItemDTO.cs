using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.DTOs
{
    public class ItemDTO
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public int categoryId{ get; set; }
        public string categoryName { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salesPrice { get; set; }
        public string imageName { get; set; }
        public string description { get; set; }
        public string gpu { get; set; }
        public string hardDisk { get; set; }
        public string processor { get; set; }
        public int? ramSize { get; set; }
        public string screenReslution { get; set; }
        public string screenSize { get; set; }
        public string weight { get; set; }
        public string itemTypeName { get; set; }
        public string osName { get; set; }
    }
}


