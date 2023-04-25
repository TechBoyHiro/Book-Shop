using Project1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Infrastructure
{
    public class LoginViewModel
    {
        [Required]
        [EmailValidation(ErrorMessage = "Enter a Valid Email Address")]
        //[EmailAddress]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        string Name { get; set; }
        [Display(Name="Remember Me ?")]
        public bool RememberMe { get; set; }
    }
}
