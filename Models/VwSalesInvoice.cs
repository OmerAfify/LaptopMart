using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class VwSalesInvoice
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int invoiceId { get; set; }
        public DateTime invoiceDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public int? deliveryManId { get; set; }
        public string notes { get; set; }
        public Guid customerId { get; set; }
    }
}
