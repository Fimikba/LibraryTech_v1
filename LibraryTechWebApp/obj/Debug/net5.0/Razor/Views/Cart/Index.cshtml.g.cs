#pragma checksum "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1d7c95a92356a878e251f1a6ecaee6c581a687c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\_ViewImports.cshtml"
using LibraryTechWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\_ViewImports.cshtml"
using LibraryTechWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
using LibraryTechWebApp.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1d7c95a92356a878e251f1a6ecaee6c581a687c", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c5e31a90e104d4c7445bf6efb0509fac2a94ed8", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LibraryTechWebApp.Models.ShowCartModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveFromCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-link btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PersonalAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuyBooks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Cart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h3 class=\"text-center\">Your cart</h3>\r\n    <hr />\r\n");
#nullable restore
#line 11 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
     if (Model.Cart.Records.Count != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1d7c95a92356a878e251f1a6ecaee6c581a687c6173", async() => {
                WriteLiteral(@"
            <table class=""table table-hover"">
                <thead>
                    <tr class=""table-active"">
                        <th width=""80%"">Book</th>
                        <th width=""10%"">Price</th>
                        <th width=""10%""></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 23 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                     foreach (var record in Model.Cart.Records)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr class=\"table-secondary\">\r\n                            <td>\r\n                                ");
#nullable restore
#line 27 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                           Write(record.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <input type=\"hidden\" name=\"records\"");
                BeginWriteAttribute("value", " value=\"", 958, "\"", 980, 1);
#nullable restore
#line 28 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
WriteAttributeValue("", 966, record.BookId, 966, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 30 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                           Write(record.Price.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1d7c95a92356a878e251f1a6ecaee6c581a687c8394", async() => {
                    WriteLiteral("Delete");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-bookId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                                                                                           WriteLiteral(record.BookId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bookId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-bookId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bookId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                                                                                                                                WriteLiteral(ViewContext.HttpContext.Request.PathAndQuery());

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 35 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr class=\"table-active\">\r\n                        <td colspan=\"2\">Total coast</td>\r\n                        <td>");
#nullable restore
#line 38 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                       Write(Model.Cart.TotalCoast.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 40 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                     if (Model.TotalCoastWithDiscount!=0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr class=\"table-active\">\r\n                        <td colspan=\"2\" class=\"text-success\">Total coast with your personal discount</td>\r\n                        <td class=\"text-success\">");
#nullable restore
#line 44 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                                            Write(Model.TotalCoastWithDiscount.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 46 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
            </table>
            <h4></h4>

            <div class=""row justify-content-md-end"">
                <div class=""col-md-auto mb-4"">
                    <a href=""#"" class=""btn btn-success"" onmousedown=""viewDiv()"">Proceed to checkout</a>
                </div>
                <div class=""w-100 d-none d-md-block""></div>
                <div class=""col-md-5 mb-4"" id=""div1"" style=""display: none;"">
                    <div class=""alert alert-dismissible alert-primary text-center"">
                        <h4 class=""alert-heading text-center"">Select a Payment Method</h4>
                        <div class=""row justify-content-md-center"">
                            <div class=""col-md-auto mb-2"">
                                <div class=""btn-group"" role=""group"" aria-label=""Basic radio toggle button group"">
                                    <input type=""radio"" class=""btn-check"" name=""paymentSystem"" value=""1"" id=""btnradio1"" autocomplete=""off""");
                BeginWriteAttribute("checked", " checked=\"", 3040, "\"", 3050, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <label class=\"btn btn-outline-light\" for=\"btnradio1\">Сredit сard</label>\r\n                                    <input type=\"radio\" class=\"btn-check\" name=\"paymentSystem\" value=\"2\" id=\"btnradio2\" autocomplete=\"off\"");
                BeginWriteAttribute("checked", " checked=\"", 3302, "\"", 3312, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <label class=\"btn btn-outline-light\" for=\"btnradio2\">PayPal</label>\r\n                                    <input type=\"radio\" class=\"btn-check\" name=\"paymentSystem\" value=\"3\" id=\"btnradio3\" autocomplete=\"off\"");
                BeginWriteAttribute("checked", " checked=\"", 3559, "\"", 3569, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    <label class=""btn btn-outline-light"" for=""btnradio3"">Apple Pay</label>
                                </div>
                            </div>
                            <div class=""w-100 d-none d-md-block""></div>
                            <div class=""col-md-auto mb-2"">
                                <input type=""submit"" value=""Pay"" class=""mb-0 btn btn-success"" />
                            </div>
                        </div>
");
                WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 81 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
    }

    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-dismissible alert-warning"">
        <h4 class=""alert-heading text-center"">Sorry, Your cart is empty :(</h4>
        <p class=""mb-0 text-center"">Choose an interesting book from the catalog and add it to the cart, you can also <a href=""#"" class=""alert-link"">purchase a subscription</a> and read your favorite books cheaper.</p>
    </div>
");
#nullable restore
#line 89 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LibraryTechWebApp.Models.ShowCartModel> Html { get; private set; }
    }
}
#pragma warning restore 1591