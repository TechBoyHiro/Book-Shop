using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Attribute
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            String st = new String(value.ToString());
            if (st.StartsWith("09") && st.Length == 11)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Enter a Valid Phone Number");
        }
    }
}
