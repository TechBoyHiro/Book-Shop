using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Infrastructure.AccountInfraStructure
{
    public class Login2FAModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Which Two Factor Code Sended to")]
        public string Email { get; }
        [Required]
        [StringLength(4, ErrorMessage = "Two Factor Code Contain 4 Char", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator code")]
        public int TwoFactorCode { get; set; }
        [Display(Name ="Rememberme ?")]
        public bool Rememberme { get; set; }
    }
}
