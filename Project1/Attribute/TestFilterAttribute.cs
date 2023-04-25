using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Infrastructure
{
    public class TestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(context.HttpContext.User.Identity.Name == "BOSS")
            {
                context.Result = new RedirectToActionResult("Index","Home",null);
            }
        }
    }
}
