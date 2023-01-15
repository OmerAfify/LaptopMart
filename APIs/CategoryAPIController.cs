using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopMart.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {

        private IMapper _mapper;
        private IItemService _itemService;
        private ICategoryService _categoryService;

        public CategoryAPIController(IMapper mapper, IItemService itemService, ICategoryService categoryService)
        { 
            _mapper = mapper;
            _itemService = itemService;
            _categoryService = categoryService;
    }




        // GET: api/<CategoryAPIController>
        [HttpGet]
        [Route("/api/GetAllCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                var catList = _categoryService.GetAllCategories().ToList();
                return Ok(catList);
            }catch(Exception ex)
            {
                return StatusCode(500, "Internal server error. Please Try again later");
            }
        }

      
    }
}
