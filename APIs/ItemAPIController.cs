using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaptopMart.DTOs;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
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


        [HttpGet]
        [Route("/api/GetItems")]
        public IActionResult GetItems()
        {
            try
            {
                var items = _itemService.GetAllVwItems().ToList();
                return Ok(_mapper.Map<List<ItemDTO>>(items));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please Try again later");
            }
        }


        [HttpGet]
        [Route("/api/GetItemsByCatId/{catId}")]
        public IActionResult GetItemsByCategoryId(int catId)
        {
            try
            {
                var items = _itemService.GetItemByCategoryId(catId).ToList();
                return Ok(_mapper.Map<List<ItemDTO>>(items));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please Try again later");
            }
        }







        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/Items")]
        public IActionResult GetItemsJWT()
        {
            try
            {

                var items = _itemService.GetAllVwItems().ToList();
                return Ok(_mapper.Map<List<ItemDTO>>(items));
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error. Please Try again later");

            }

        }


    }
}
