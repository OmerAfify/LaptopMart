using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface IOsService
    {
        public IEnumerable<OS> GetAllOS();
        public OS GetOSById(int id);
        public void AddOS(OS OS);
        public void UpdateOS(OS OS);
        public void DeleteOS(int id);

    }
}
