#pragma checksum "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\PersonalAccount\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b26b3897b2b10f562a0c6d29408ef683a58a1112"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PersonalAccount_Index), @"mvc.1.0.view", @"/Views/PersonalAccount/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b26b3897b2b10f562a0c6d29408ef683a58a1112", @"/Views/PersonalAccount/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c5e31a90e104d4c7445bf6efb0509fac2a94ed8", @"/Views/_ViewImports.cshtml")]
    public class Views_PersonalAccount_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LibraryTechWebApp.Models.BookModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\PersonalAccount\Index.cshtml"
      
        ViewData["Title"] = "Profile";
        Layout = "PersonalAccountLayout";
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <h1></h1>
    <h3 class=""text-center"">Your profile</h3>
    <hr />

    <div>
        <h4 class=""text-center"">Last books that you reading by subscription:</h3>
        <div class=""bs-component"">
            <div class=""row justify-content-center"">
");
#nullable restore
#line 15 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\PersonalAccount\Index.cshtml"
                 foreach (var b in Model)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\PersonalAccount\Index.cshtml"
               Write(await Html.PartialAsync("ProfileSubBooksPartialView", b));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\PersonalAccount\Index.cshtml"
                                                                             
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LibraryTechWebApp.Models.BookModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
