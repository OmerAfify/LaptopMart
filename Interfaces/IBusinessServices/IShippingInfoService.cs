using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface IShippingInfoService
    {
        public void AddShippingInfo(ShippingInfo shippingInfo);


    }
}
