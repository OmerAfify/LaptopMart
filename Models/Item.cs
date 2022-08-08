using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class Item
    {
        public Item()
        {
            customerItems = new HashSet<customerItem>();
            itemDiscounts = new HashSet<ItemDiscount>();
            itemImages = new HashSet<ItemImage>();
            purchaseInvoiceItems = new HashSet<PurchaseInvoiceItem>();
            salesInvoiceItems = new HashSet<salesInvoiceItem>();
        }

        public int itemId { get; set; }
        public string itemName { get; set; }
        public decimal salesPrice { get; set; }
        public decimal purchasePrice { get; set; }
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

        public virtual Category category { get; set; }
        public virtual ItemType itemType { get; set; }
        public virtual OS os { get; set; }
        public virtual ICollection<customerItem> customerItems { get; set; }
        public virtual ICollection<ItemDiscount> itemDiscounts { get; set; }
        public virtual ICollection<ItemImage> itemImages { get; set; }
        public virtual ICollection<PurchaseInvoiceItem> purchaseInvoiceItems { get; set; }
        public virtual ICollection<salesInvoiceItem> salesInvoiceItems { get; set; }
    }
}
