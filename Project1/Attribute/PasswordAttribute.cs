using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookWebApp.Attribute
{
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string patdi = @"\d+"; //match digits
            string patupp = @"[A-Z]+"; //match upper cases
            string patlow = @"[a-z]+"; //match lower cases
            string patsym = @"[`~!@$%^&\\-\\+*/_=,;.':|\\(\\)\\[\\]\\{\\}]+"; //match symbols
            Match id = Regex.Match(value.ToString(), patdi);
            Match upp = Regex.Match(value.ToString(), patupp);
            Match low = Regex.Match(value.ToString(), patlow);
            Match sym = Regex.Match(value.ToString(), patsym);
            if (id.Success && upp.Success && low.Success && sym.Success)
            {
                return true;
            }
            else
            {
                ErrorMessage = "Password Contain At least One Upper And Lower and Symbol";
                return false;
            }
        }
    }
}
