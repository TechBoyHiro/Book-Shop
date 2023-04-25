using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Infrastructure.AccountInfraStructure
{
    public class ForgetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
