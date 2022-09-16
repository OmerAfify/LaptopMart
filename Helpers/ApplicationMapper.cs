using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaptopMart.DTOs;
using LaptopMart.Models;

namespace LaptopMart.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<VwItem, ItemDTO>().ReverseMap();

        }

       
    }
}
