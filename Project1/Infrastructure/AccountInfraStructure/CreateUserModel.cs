using BookWebApp.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Infrastructure.AccountInfraStructure
{
    public class CreateUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public virtual string Email { get; set; }
        [PhoneNumber]
        public virtual string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("Password",ErrorMessage ="Password And Confirmation Password Do Not Match")]
        public string ConfirmPassword { get; set; }
        public bool SendNotification { get; set; }
    }
}
