#pragma checksum "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\ResetPasswordConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f44ce7764a438f4ad0ec2ea4f32fcd83b7dcf256"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ResetPasswordConfirmation), @"mvc.1.0.view", @"/Views/Account/ResetPasswordConfirmation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ResetPasswordConfirmation.cshtml", typeof(AspNetCore.Views_Account_ResetPasswordConfirmation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f44ce7764a438f4ad0ec2ea4f32fcd83b7dcf256", @"/Views/Account/ResetPasswordConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f8a1206ad760d99a32967ca6cf008da4df4ac8e", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ResetPasswordConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Account\ResetPasswordConfirmation.cshtml"
  
    ViewData["Title"] = "ResetPasswordConfirmation";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(110, 899, true);
            WriteLiteral(@"
<section class=""w-100 h-100"" onload=""Start();"">
    <div class=""container w-100"">
        <div class=""row w-100 h-100"">
            <div class=""col text-center"">
                <h3 class=""text-success mt-5 text-center display-4"">Your Password Reset Successfully</h3>
                <p class=""text-muted lead"">You Will Redirect To Login Page In <span id=""counter""></span></p>
            </div>
        </div>
    </div>
</section>

<script>

    window.setTimeout(function () {
        window.location.href = '/Home/index';
    }, 4000);

    function Start() {
        var counter = document.getElementById(""counter"");
        counter.value = 4;
        setTimeout('Timer', 1000);
    }
    function Timer() {
        var counter = document.getElementById(""counter"");
        var currentt = counter.value;
        counter.value = currentt - 1;
    }
</script>



");
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
