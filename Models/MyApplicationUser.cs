using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LaptopMart.Models
{
    public class MyApplicationUser : IdentityUser
    {
        public string firstName{ get; set; }
        public string lastName{ get; set; }
    }
}
