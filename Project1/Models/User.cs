using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Project1.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Project1.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage ="Please Enter Name")]
        public string name { get; set; }
        [Required(ErrorMessage ="Enter valid UserName")]
        public override string UserName { get; set; }
        [Required]
        public string password { get; set; }
        public int TwofactorCode { get; set; }
        [Key]
        public long userid { get; set; }
        [EmailValidation(ErrorMessage ="Enter a Valid Email-Address")]
        public bool SendNotification { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
