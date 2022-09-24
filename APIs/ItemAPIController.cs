using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaptopMart.DTOs;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LaptopMart.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAPIController : ControllerBase
    {

        private IMapper _mapper;
        private IItemService _itemService;

        public ItemAPIController(IMapper mapper, IItemService itemService)
        {
            _mapper = mapper;
            _itemService = itemService;
        }



        // GET: api/<ItemAPIController>
        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/Items")]
        public IActionResult Get()
        {
            try {

                var items = _itemService.GetAllVwItems().ToList();
                return Ok(_mapper.Map<List<ItemDTO>>(items));
            } catch (Exception ex) {

                return StatusCode(500, "Internal server error. Please Try again later");
            
            }

        }

     
        // GET api/<ItemAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
