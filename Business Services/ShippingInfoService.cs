using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;

namespace LaptopMart.Business_Services
{
    public class ShippingInfoService : IShippingInfoService
    {
        private LapShopContext _context { get; set; }
        public ShippingInfoService(LapShopContext context)
        {
            _context = context;
        }
        public void AddShippingInfo(ShippingInfo shippingInfo)
        {

            _context.Tb_ShippingInfo.Add(shippingInfo);
            _context.SaveChanges();

        }


    }
}
