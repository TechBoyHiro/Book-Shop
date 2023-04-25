using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Infrastructure
{
    public class MustBeTrue : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && value is bool && (bool)value == true;
        }
    }
}
