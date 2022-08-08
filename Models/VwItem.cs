using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class VwItem
    {
        public string itemName { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salesPrice { get; set; }
        public int categoryId { get; set; }
        public string imageName { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public int currentState { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string description { get; set; }
        public string gpu { get; set; }
        public string hardDisk { get; set; }
        public int? itemTypeId { get; set; }
        public string processor { get; set; }
        public int? ramSize { get; set; }
        public string screenReslution { get; set; }
        public string screenSize { get; set; }
        public string weight { get; set; }
        public int? osId { get; set; }
        public string categoryName { get; set; }
        public string itemTypeName { get; set; }
        public string osName { get; set; }
        public int itemId { get; set; }
    }
}
