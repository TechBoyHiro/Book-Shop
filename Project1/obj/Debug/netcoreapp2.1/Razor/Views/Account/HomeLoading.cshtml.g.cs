#pragma checksum "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\HomeLoading.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06f6565b91914bbf8a2de596c3c9827ea4a00a84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_HomeLoading), @"mvc.1.0.view", @"/Views/Account/HomeLoading.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/HomeLoading.cshtml", typeof(AspNetCore.Views_Account_HomeLoading))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\_ViewImports.cshtml"
using Project1;

#line default
#line hidden
#line 2 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\_ViewImports.cshtml"
using Project1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06f6565b91914bbf8a2de596c3c9827ea4a00a84", @"/Views/Account/HomeLoading.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f8a1206ad760d99a32967ca6cf008da4df4ac8e", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_HomeLoading : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\HomeLoading.cshtml"
  
    ViewData["Title"] = "Home Loading";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(95, 170, true);
            WriteLiteral("\r\n\r\n\r\n    <section class=\"w-100 h-100\">\r\n        <div class=\"container w-100\">\r\n            <div class=\"row w-100 h-100\">\r\n                <div class=\"col text-center\">\r\n");
            EndContext();
#line 12 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\HomeLoading.cshtml"
                     while (!User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
            BeginContext(349, 219, true);
            WriteLiteral("                        <h4 class=\"display-4 mt-4\">Loading <div class=\"spinner-grow mb-2 text-  danger\"></div> <div class=\"spinner-grow mb-2 text-success\"></div> <div class=\"spinner-grow mb-2 text-primary\"></div></h4>\r\n");
            EndContext();
#line 15 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\HomeLoading.cshtml"
                    }

#line default
#line hidden
            BeginContext(591, 78, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n");
            EndContext();
#line 21 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\HomeLoading.cshtml"
    if(User.Identity.IsAuthenticated)
   {

#line default
#line hidden
            BeginContext(714, 140, true);
            WriteLiteral("       <script>\r\n             window.setTimeout(function () {\r\n        window.location.href = \'/Home/index\';\r\n    }, 0);\r\n       </script>\r\n");
            EndContext();
#line 28 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\HomeLoading.cshtml"
   }

#line default
#line hidden
            BeginContext(860, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591