#pragma checksum "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5d707236bc94dc9ee3d0c97bd80ed6fe3d894a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderDetails), @"mvc.1.0.view", @"/Views/Order/OrderDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5d707236bc94dc9ee3d0c97bd80ed6fe3d894a9", @"/Views/Order/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19afbdf37e0630b3316d1d4fea08a9b48e68231b", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderDetailsPageViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Website/images/pro3/1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid blur-up lazyload"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
 <!-- breadcrumb start -->
<div class=""breadcrumb-section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-sm-6"">
                <div class=""page-title"">
                    <h2>customer's Orders</h2>
                </div>
            </div>
            <div class=""col-sm-6"">
                <nav aria-label=""breadcrumb"" class=""theme-breadcrumb"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
                        <li class=""breadcrumb-item active"">Orders</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>
<!-- breadcrumb End -->
<!-- order-detail section start -->
<section class=""section-b-space"">
    <div class=""container"">


");
#nullable restore
#line 29 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <section class=""section-b-space light-layout"">
                <div class=""container"">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""success-text"">
                               <h2>No orders are available.</h2>
                                <p>Currently you have no orders to track</p>
                               ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5d707236bc94dc9ee3d0c97bd80ed6fe3d894a98642", async() => {
                WriteLiteral(" Add New Order?");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </section>\r\n");
#nullable restore
#line 44 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n        <!--loop here-->\r\n");
#nullable restore
#line 50 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
         foreach (var order in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\" style=\"margin-bottom:150px\">\r\n                <div class=\"col-lg-6\">\r\n                    <div class=\"product-order\">\r\n                        <h3>Order No : ");
#nullable restore
#line 55 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                  Write(order.order.orderId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n\r\n                        <!--loop through div class row prod order detail-->\r\n");
#nullable restore
#line 58 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                         foreach (var orderedItem in order.orderedItems)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"row product-order-detail\">\r\n                                <div class=\"col-3\">\r\n");
#nullable restore
#line 62 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                       if (!string.IsNullOrEmpty(orderedItem.item.imageName))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <img");
            BeginWriteAttribute("src", " src=", 2373, "", 2453, 1);
#nullable restore
#line 64 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
WriteAttributeValue("", 2378, string.Format("/Uploads/Images/ItemImages/{0}",orderedItem.item.imageName), 2378, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2453, "\"", 2459, 0);
            EndWriteAttribute();
            WriteLiteral("\r\n                                                 class=\"img-fluid blur-up lazyload\">\r\n");
#nullable restore
#line 66 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"

                                            
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d5d707236bc94dc9ee3d0c97bd80ed6fe3d894a913432", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 73 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"

                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                                <div class=""col-3 order_detail"">
                                    <div>
                                        <h4>product name</h4>
                                        <h5>");
#nullable restore
#line 81 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                       Write(orderedItem.item.itemName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                    </div>
                                </div>
                                <div class=""col-3 order_detail"">
                                    <div>
                                        <h4>quantity</h4>
                                        <h5>");
#nullable restore
#line 87 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                       Write(orderedItem.totalQty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                    </div>
                                </div>
                                <div class=""col-3 order_detail"">
                                    <div>
                                        <h4>price</h4>
                                        <h5>$ ");
#nullable restore
#line 93 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                         Write(orderedItem.totalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 97 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        <div class=\"total-sec\">\r\n                            <ul>\r\n                                <li>subtotal <span>$ ");
#nullable restore
#line 102 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                                Write(order.order.totalOrderPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></li>
                                <li>shipping <span>$ 100</span></li>

                            </ul>
                        </div>
                        <div class=""final-total"">
                            <h3>total Quantity <span>");
#nullable restore
#line 108 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                                Write(order.order.totalOrderQty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h3>\r\n                        </div>\r\n                        <div class=\"final-total\">\r\n                            <h3>total Price <span>$ ");
#nullable restore
#line 111 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                               Write(order.order.totalOrderPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></h3>
                        </div>


                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""row order-success-sec"">
                        <div class=""col-sm-6"">
                            <h4>summary</h4>
                            <ul class=""order-detail"">
                                <li>For Mr/s : ");
#nullable restore
#line 122 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                          Write(order.order.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 122 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                                                 Write(order.order.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n                                <li>order ID: ");
#nullable restore
#line 123 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                         Write(order.order.orderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>Order Date: ");
#nullable restore
#line 124 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                           Write(order.order.orderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>Order Status: ");
#nullable restore
#line 125 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                             Write(order.order.orderStatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                                <li> </li>
                            </ul>
                        </div>
                        <div class=""col-sm-6"">
                            <h4>shipping address</h4>
                            <ul class=""order-detail"">
                                <li>Country :  ");
#nullable restore
#line 132 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                          Write(order.order.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>City: ");
#nullable restore
#line 133 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                     Write(order.order.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>Address : ");
#nullable restore
#line 134 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                         Write(order.order.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>Contact No :  ");
#nullable restore
#line 135 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                                             Write(order.order.phoneNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            </ul>\r\n                        </div>\r\n                        <div class=\"col-sm-12 payment-mode\">\r\n                            <h4>payment method</h4>\r\n                            <p>\r\n                                ");
#nullable restore
#line 141 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                           Write(order.order.PayementType);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""delivery-sec"">
                                <h3>expected date of delivery</h3>
                                <h2>");
#nullable restore
#line 147 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
                               Write(order.order.DeliveryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <hr />\r\n");
#nullable restore
#line 155 "D:\6-Programming and courses\My Local Projects Repository\ASP.net MVC\LaptopMart\LaptopMart\Views\Order\OrderDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</section>\r\n<!-- Section ends -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderDetailsPageViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
