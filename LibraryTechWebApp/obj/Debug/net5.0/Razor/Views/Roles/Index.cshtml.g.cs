#pragma checksum "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc2a93827cf1f0e8837b252d824d6dc831e9b637"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_Index), @"mvc.1.0.view", @"/Views/Roles/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc2a93827cf1f0e8837b252d824d6dc831e9b637", @"/Views/Roles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c5e31a90e104d4c7445bf6efb0509fac2a94ed8", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::LibraryTechWebApp.Helpers.RoleUserTagHelper __LibraryTechWebApp_Helpers_RoleUserTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
   
    Layout = "AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""alert alert-dismissible alert-primary m-3"">
    <h4 align=""center"">Roles in the system</h4>
</div>

<table class=""table table-bordered table-hover"">
    <tr>
        <th>Role ID</th>
        <th>Name</th>
        <th>Users</th>
        <th>Actions</th>
    </tr>
");
#nullable restore
#line 18 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td colspan=\"4\">No roles</td>\n        </tr>\n");
#nullable restore
#line 23 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
    }
    else
    {
        foreach (var role in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 29 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
               Write(role.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 30 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
               Write(role.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("td", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc2a93827cf1f0e8837b252d824d6dc831e9b6376345", async() => {
            }
            );
            __LibraryTechWebApp_Helpers_RoleUserTagHelper = CreateTagHelper<global::LibraryTechWebApp.Helpers.RoleUserTagHelper>();
            __tagHelperExecutionContext.Add(__LibraryTechWebApp_Helpers_RoleUserTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
                    WriteLiteral(role.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __LibraryTechWebApp_Helpers_RoleUserTagHelper.Role = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("role-users", __LibraryTechWebApp_Helpers_RoleUserTagHelper.Role, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                <td>\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc2a93827cf1f0e8837b252d824d6dc831e9b6377932", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-roleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
                                                                       WriteLiteral(role.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-roleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 36 "D:\c#\5 УРОВЕНЬ ВЭБРАЗРАБОТКА\FinalProject\LibraryTechWebApp\LibraryTechWebApp\Views\Roles\Index.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc2a93827cf1f0e8837b252d824d6dc831e9b63710518", async() => {
                WriteLiteral("Create new role");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
