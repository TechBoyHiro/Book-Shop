#pragma checksum "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3e195edd1347eaa539ad08d74699b5dabfb5973"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_SearchBooks), @"mvc.1.0.view", @"/Views/Book/SearchBooks.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Book/SearchBooks.cshtml", typeof(AspNetCore.Views_Book_SearchBooks))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3e195edd1347eaa539ad08d74699b5dabfb5973", @"/Views/Book/SearchBooks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f8a1206ad760d99a32967ca6cf008da4df4ac8e", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_SearchBooks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Book>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/slick.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tether.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
  
    ViewData["Title"] = "SearchBooks";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(120, 116, true);
            WriteLiteral("\r\n\r\n\r\n<section>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col text-center\">\r\n");
            EndContext();
#line 13 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
                 if (ViewBag.searchR == true)
                {

#line default
#line hidden
            BeginContext(302, 68, true);
            WriteLiteral("                    <h3 class=\"display-4 mt-3\">Search Resault</h3>\r\n");
            EndContext();
#line 16 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(430, 81, true);
            WriteLiteral("                    <h3 class=\"display-4 mt-3 text-danger\">Book Not Found!</h3>\r\n");
            EndContext();
#line 20 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
                }

#line default
#line hidden
            BeginContext(530, 114, true);
            WriteLiteral("                <hr class=\"w-75 mt-2 bg-success\">\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 25 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
             foreach (Book item in Model)
            {

#line default
#line hidden
            BeginContext(702, 359, true);
            WriteLiteral(@"                <div class=""col-12"">
                    <a href=""#"">
                        <div class=""card mb-4"" style=""border:1px black solid;"">
                            <div class=""card-block"">
                                <div class=""row"">
                                    <div class=""col-4"">
                                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1061, "\"", 1080, 1);
#line 33 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
WriteAttributeValue("", 1067, item.imgpath, 1067, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1081, 290, true);
            WriteLiteral(@" class=""img-fluid"">
                                    </div>
                                    <div class=""col-8"">
                                        <h3 class=""text-left d-inline text-primary"">Book Name : </h3>
                                        <p class=""d-inline mb-5"">");
            EndContext();
            BeginContext(1372, 9, false);
#line 37 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
                                                            Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1381, 311, true);
            WriteLiteral(@"</p>
                                        <br>
                                        <br>
                                        <br>
                                        <h3 class=""text-left  text-primary  d-inline "">Book Title : </h3>
                                        <p class=""d-inline"">");
            EndContext();
            BeginContext(1693, 16, false);
#line 42 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
                                                       Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1709, 208, true);
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </a>\r\n                </div>\r\n");
            EndContext();
#line 49 "F:\Source's\Asp.Net Core\BookMicrosoftVersion\Project1\Views\Book\SearchBooks.cshtml"
            }

#line default
#line hidden
            BeginContext(1932, 311, true);
            WriteLiteral(@"        </div>
    </div>
</section>



<script src=""https://code.jquery.com/jquery-3.2.1.min.js""
        integrity=""sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=""
        crossorigin=""anonymous""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.js""></script>
");
            EndContext();
            BeginContext(2243, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aacdf227cfaa4081a15de2be8e0c1037", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2288, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2290, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ec3f5504ad34e9ca2a931cc0d4934fe", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2355, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2357, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70256a6f1d8940c4bf96fec67ca229df", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2394, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2396, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a281c3afe98d4c449be8befc2c7e5d79", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2455, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2457, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b5354cbd08406ca79ffa2f64012e39", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2499, 335, true);
            WriteLiteral(@"
<script src=""//code.jquery.com/jquery-1.10.2.js""></script>
<script src=""//code.jquery.com/ui/1.11.4/jquery-ui.js""></script>



<script>
    $('.card').focus(function () {
        $(this).css({ ""background-color"": ""#ffff"", ""color"": ""rgb(248,250,2)"" });
        //$(this).css(""color"", ""rgb(248,250,2)"");
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591