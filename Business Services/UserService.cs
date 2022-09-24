using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LaptopMart.Business_Services
{
    public class UserService : IUserService
    {

         private MyApplicationUser _user;
         private readonly UserManager<MyApplicationUser> _userManager;
         private readonly IConfiguration _congfiguration;


        public UserService (UserManager<MyApplicationUser> userManager, IConfiguration congfiguration)
        {
       
          _userManager = userManager;
          _congfiguration = congfiguration;

        }


        public async Task<bool> ValidateUser(LoginUser loginUser) {

            _user = await _userManager.FindByNameAsync(loginUser.email);

            if (_user != null && await _userManager.CheckPasswordAsync(_user, loginUser.password))
                return true;
            else
                return false;
        }

        public async Task<string> CreateToken() {

            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claimsList)
        {
           var jwtSettings = _congfiguration.GetSection("JWT");

            var tokenOptions = new JwtSecurityToken(

                issuer: _congfiguration["JWT:ValidIssuer"],
                audience: _congfiguration["JWT:ValidAudience"],
                claims: claimsList,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value)),
                signingCredentials: signingCredentials

                );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.Email)
            };

            var roles = await _userManager.GetRolesAsync(_user);


            foreach(var role in roles)
            {
                claimsList.Add(new Claim(ClaimTypes.Role, role));
            }

            return claimsList;

        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _congfiguration["Jwt:Key"];
            var secretEncodedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var signingCredentials = new SigningCredentials(secretEncodedKey, SecurityAlgorithms.HmacSha256);

            return signingCredentials;
        }
    }
}
