using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace LaptopMart.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {

        private IUserService _userService;

        public UserAPIController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        [Route("/api/loginWithJwt")]
        public async Task<IActionResult> LoginWithJwt([FromBody] LoginUser user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _userService.ValidateUser(user))
                    return Unauthorized();
                else
                    return Accepted(new { token = await _userService.CreateToken() });

            }
            catch (Exception ex)
            {

                return Problem($"Something went wrong " + ex.InnerException.Message);
            }


        }

    }
}
