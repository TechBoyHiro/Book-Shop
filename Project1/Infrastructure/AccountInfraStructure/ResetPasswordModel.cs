using BookWebApp.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Infrastructure.AccountInfraStructure
{
    public class ResetPasswordModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Password]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Compare("Password",ErrorMessage ="Password Do Not Match The Confirmation Password")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
