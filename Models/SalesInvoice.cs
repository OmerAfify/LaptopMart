using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class salesInvoice
    {
        public salesInvoice()
        {
            salesInvoiceItems = new HashSet<salesInvoiceItem>();
        }

        public int invoiceId { get; set; }
        public DateTime invoiceDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public int? deliveryManId { get; set; }
        public string notes { get; set; }
        public Guid customerId { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int currentState { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }

        public virtual ICollection<salesInvoiceItem> salesInvoiceItems { get; set; }
    }
}
