#pragma checksum "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "116e8988ea6d3a4e7eb514bb76a3c3484a709977"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderSuccess), @"mvc.1.0.view", @"/Views/Order/OrderSuccess.cshtml")]
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
#line 1 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart.Resources.ProductResources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using LaptopMart.Resources.ShoppingCartResources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"116e8988ea6d3a4e7eb514bb76a3c3484a709977", @"/Views/Order/OrderSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19afbdf37e0630b3316d1d4fea08a9b48e68231b", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- thank-you section start -->
<section class=""section-b-space light-layout"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""success-text"">
                    <i class=""fa fa-check-circle"" aria-hidden=""true""></i>
                    <h2>thank you</h2>
                    <p>Payment is successfully processsed and your order is on the way</p>
                    <p>Order ID : ");
#nullable restore
#line 11 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderSuccess.cshtml"
                             Write(ViewBag.orderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Section ends -->");
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
