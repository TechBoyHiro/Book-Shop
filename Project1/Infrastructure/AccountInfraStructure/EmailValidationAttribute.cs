using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Infrastructure
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string && value.ToString().Contains("@") && value.ToString().Contains(".com");
        }
    }
}
