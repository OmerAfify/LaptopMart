using System;
using System.Collections.Generic;

#nullable disable

namespace LaptopMart.Models
{
    public partial class CashTransacion
    {
        public int cashTransactionId { get; set; }
        public int customerId { get; set; }
        public DateTime cashDate { get; set; }
        public decimal cashValue { get; set; }
    }
}
