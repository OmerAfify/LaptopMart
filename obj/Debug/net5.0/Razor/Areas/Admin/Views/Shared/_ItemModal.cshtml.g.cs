#pragma checksum "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Areas\Admin\Views\Shared\_ItemModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc792e08665a351b0e5081bb3fe2d80fbb81bfa4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__ItemModal), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_ItemModal.cshtml")]
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
#nullable restore
#line 1 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Areas\Admin\Views\_ViewImports.cshtml"
using LaptopMart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Areas\Admin\Views\_ViewImports.cshtml"
using LaptopMart.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc792e08665a351b0e5081bb3fe2d80fbb81bfa4", @"/Areas/Admin/Views/Shared/_ItemModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f83b49013922c5cfc3d2fd67d777570234e6f5a6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__ItemModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Item>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div>\r\n        <ul class=\"list-group\">\r\n            <li class=\"list-group-item\">");
#nullable restore
#line 5 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Areas\Admin\Views\Shared\_ItemModal.cshtml"
                                   Write(Model.itemId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            <li class=\"list-group-item\">");
#nullable restore
#line 6 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Areas\Admin\Views\Shared\_ItemModal.cshtml"
                                   Write(Model.itemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            <li class=\"list-group-item\">");
#nullable restore
#line 7 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Areas\Admin\Views\Shared\_ItemModal.cshtml"
                                   Write(Model.itemType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        </ul>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
