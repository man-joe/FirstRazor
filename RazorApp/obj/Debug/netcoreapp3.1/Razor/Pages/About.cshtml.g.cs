#pragma checksum "R:\cs_repos\RazorApp\RazorApp\Pages\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1e86d328e5fce425abef28c10a024d06c282279"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorApp.Pages.Pages_About), @"mvc.1.0.razor-page", @"/Pages/About.cshtml")]
namespace RazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "R:\cs_repos\RazorApp\RazorApp\Pages\_ViewImports.cshtml"
using RazorApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1e86d328e5fce425abef28c10a024d06c282279", @"/Pages/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff61db7ceeaf19f23c1ec3102ef750fd1a6a679e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_About : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "R:\cs_repos\RazorApp\RazorApp\Pages\About.cshtml"
  
    ViewData["Title"] = "Restaurant Statistics";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Restaurant Statistics</h1>\r\n\r\n<table>\r\n    <tr>\r\n        <th>\r\n            Menu Date\r\n        </th>\r\n        <th>\r\n            Foods\r\n        </th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 19 "R:\cs_repos\RazorApp\RazorApp\Pages\About.cshtml"
     foreach (var item in Model.Foods)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 23 "R:\cs_repos\RazorApp\RazorApp\Pages\About.cshtml"
           Write(Html.DisplayFor(modelItem => item.MenuDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "R:\cs_repos\RazorApp\RazorApp\Pages\About.cshtml"
           Write(item.FoodCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 29 "R:\cs_repos\RazorApp\RazorApp\Pages\About.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorApp.Pages.AboutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorApp.Pages.AboutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorApp.Pages.AboutModel>)PageContext?.ViewData;
        public RazorApp.Pages.AboutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591