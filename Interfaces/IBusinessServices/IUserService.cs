using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface IUserService
    {
        public Task<bool> ValidateUser(LoginUser loginUser);
        public Task<string> CreateToken();

    }
}
