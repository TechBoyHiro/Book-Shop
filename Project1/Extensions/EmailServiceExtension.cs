using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace BookWebApp.Extensions
{
    public static class EmailServiceExtension
    {
        public static Task SendEmailLinkAsync(this EmailService emailsender , string email,string callbacklink)
        {
            return emailsender.SendEmailAsync(email, "Confirm Your Email", $"Please Confirm Your Account By Clicking : <a href='{HtmlEncoder.Default.Encode(callbacklink)}' class='display-4 text-success'>Confirm</a>");
        }
    }
}
