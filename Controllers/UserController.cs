using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LaptopMart.Controllers
{
    public class UserController : Controller
    {
        private UserManager<MyApplicationUser> _userManager;
        private SignInManager<MyApplicationUser> _signInManager;
        public UserController(UserManager<MyApplicationUser> userManager, SignInManager<MyApplicationUser> signInManager) {

            _userManager = userManager;
            _signInManager = signInManager;
        
        }


        public IActionResult Register()
        {
            return View(new RegisterUser());
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            if (ModelState.IsValid) {

                var newUser = new MyApplicationUser()
                {
                    firstName = user.firstName,
                    lastName = user.lastName,
                    Email = user.email,
                    UserName = user.email,

                };

                var RegisterationResult =await _userManager.CreateAsync(newUser, user.password);

                if (RegisterationResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser,"Customer");


                    await _signInManager.PasswordSignInAsync(user.email, user.password, true, false);
                    return Redirect("~/");

                }
                else
                {
                    List<IdentityError> errors = RegisterationResult.Errors.ToList();
                    ViewBag.errors = errors;
             
                    return View("Register", user);
                }


            } 
            else { 

              return View("Register", user);
            }
          
        }




        public IActionResult Login(string returnUrl)
        {
            return View(new LoginUser());
        }
  
        
       [HttpPost]
        public async Task<IActionResult> Login(LoginUser user , string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.email, user.password, true, false);

                if (result.Succeeded)
                {
                    //return url is send via asp-route-returnUrl="@Context.Request.Query["ReturnUrl"] in the view
                    if (!String.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }

                // not succeeded
                var userResult = await _userManager.FindByNameAsync(user.email);
                var errors = new List<string>();

                if (result.IsNotAllowed)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(userResult))
                    {
                        errors.Add("E-mail Address is not confirmed.");
                    }

                    if (!await _userManager.IsPhoneNumberConfirmedAsync(userResult))
                    {
                        errors.Add("Phone Number is not confirmed.");
                    }
                }
                else if (result.IsLockedOut)
                {
                    errors.Add("Your account is currently locked out. Please try again later.");

                }
                else if (result.RequiresTwoFactor)
                {
                    errors.Add("Account requires 2 factors.");
                }
                else
                {
                    // Username or password is incorrect.

                    if (userResult == null)
                    {
                        errors.Add("E-mail doesn't exist.");
                    }
                    else
                    {
                        errors.Add("Password dosn't match the requested email.");
                    }
                }

                    ViewBag.errors = errors;
                    return View("Login", user);
            }
            else
            { 
            return View("Login", user);
            }
        }
       
        
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            return Redirect("~/");
        } 
        

        public IActionResult AccessDenied()
        {
            return View();
        }
        
      


    }
}
