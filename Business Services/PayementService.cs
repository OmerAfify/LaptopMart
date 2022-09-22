using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;

namespace LaptopMart.Business_Services
{
    public class PayementService : IPayementService
    {
        private LapShopContext _context;
        public PayementService(LapShopContext context) {

            _context = context;
        }

        public IEnumerable<Payement> GetAllPayments()
        {
            return _context.Tb_Payement;

        }

      
    }
}
