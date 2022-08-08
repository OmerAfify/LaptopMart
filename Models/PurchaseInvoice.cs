using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class PurchaseInvoice
    {
        public PurchaseInvoice()
        {
            purchaseInvoiceItems = new HashSet<PurchaseInvoiceItem>();
        }

        public int invoiceId { get; set; }
        public DateTime invoiceDate { get; set; }
        public int supplierId { get; set; }
        public string notes { get; set; }

        public virtual Supplier supplier { get; set; }
        public virtual ICollection<PurchaseInvoiceItem> purchaseInvoiceItems { get; set; }
    }
}
