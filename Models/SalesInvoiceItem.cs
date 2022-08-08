using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class salesInvoiceItem
    {
        public int invoiceItemId { get; set; }
        public int itemId { get; set; }
        public int invoiceId { get; set; }
        public double qty { get; set; }
        public decimal invoicePrice { get; set; }
        public string notes { get; set; }

        public virtual salesInvoice invoice { get; set; }
        public virtual Item item { get; set; }
    }
}
