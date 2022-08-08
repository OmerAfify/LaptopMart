using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            purchaseInvoices = new HashSet<PurchaseInvoice>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public virtual ICollection<PurchaseInvoice> purchaseInvoices { get; set; }
    }
}
