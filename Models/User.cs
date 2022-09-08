using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopMart.Models
{
    public class LoginUser
    {

        [Required(ErrorMessage = "Please enter your Email.")]
        public string email { get; set; }


        [Required(ErrorMessage = "Please enter a valid Password.")]
        public string password { get; set; }
   
    }

    public class RegisterUser : LoginUser
    {

        [Required(ErrorMessage ="Please enter your first Name.")]
        public string firstName { get; set; }
        
        
        [Required(ErrorMessage = "Please enter your last Name.")]
        public string lastName { get; set; }

   
    }
}
