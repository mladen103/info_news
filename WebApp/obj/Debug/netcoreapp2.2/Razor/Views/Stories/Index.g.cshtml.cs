#pragma checksum "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16a3af7161ab38f170bbe43b2a72ec5304bae02e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stories_Index), @"mvc.1.0.view", @"/Views/Stories/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stories/Index.cshtml", typeof(AspNetCore.Views_Stories_Index))]
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
#line 1 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16a3af7161ab38f170bbe43b2a72ec5304bae02e", @"/Views/Stories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Stories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.Responses.PagedResponse<Application.DataTransferObjects.StoryDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(86, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(129, 246, true);
            WriteLiteral("\r\n<style>\r\n    .row {\r\n        display: flex; /* equal height of the children */\r\n    }\r\n\r\n    .col {\r\n        flex: 1; /* additionally, equal width */\r\n        padding: 1em;\r\n        border: solid;\r\n    }\r\n</style>\r\n\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(375, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16a3af7161ab38f170bbe43b2a72ec5304bae02e4937", async() => {
                BeginContext(398, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(412, 29, true);
            WriteLiteral("\r\n</p>\r\n\r\n<div class=\"row\">\r\n");
            EndContext();
#line 26 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
     foreach (var item in Model.Data)
    {

#line default
#line hidden
            BeginContext(487, 118, true);
            WriteLiteral("        <div class=\"col-md-4\">\r\n            <div class=\"thumbnail\">\r\n                <img width=\"100px\" height=\"200px\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 605, "\"", 668, 2);
            WriteAttributeValue("", 611, "/uploads/", 611, 9, true);
#line 30 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
WriteAttributeValue("", 620, Html.DisplayFor(modelItem => item.Picture.Path), 620, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 669, "\"", 723, 1);
#line 30 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
WriteAttributeValue("", 675, Html.DisplayFor(modelItem => item.Picture.Name), 675, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(724, 91, true);
            WriteLiteral(" style=\"width:100%\">\r\n                <div class=\"caption\">\r\n                    <h3>Name: ");
            EndContext();
            BeginContext(816, 39, false);
#line 32 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                         Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(855, 38, true);
            WriteLiteral("</h3>\r\n                    <p>Active: ");
            EndContext();
            BeginContext(894, 43, false);
#line 33 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                          Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(937, 99, true);
            WriteLiteral("</p>\r\n                    <hr />\r\n                    <p>\r\n                        Journalists:\r\n\r\n");
            EndContext();
#line 38 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                         foreach (var journalist in item.Journalists)
                        {
                            

#line default
#line hidden
            BeginContext(1163, 19, false);
#line 40 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                       Write(journalist.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1189, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1199, 20, false);
#line 40 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                                                           Write(journalist.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1219, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1222, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
#line 41 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(1252, 80, true);
            WriteLiteral("\r\n\r\n                    </p>\r\n\r\n                    <hr />\r\n                    ");
            EndContext();
            BeginContext(1333, 53, false);
#line 47 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1386, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1411, 59, false);
#line 48 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1470, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1494, 157, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16a3af7161ab38f170bbe43b2a72ec5304bae02e10709", async() => {
                BeginContext(1558, 86, true);
                WriteLiteral("\r\n                        <input type=\"submit\" value=\"Delete\" />\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
                                                              WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1651, 92, true);
            WriteLiteral("\r\n                    <hr />\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 57 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1750, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.Responses.PagedResponse<Application.DataTransferObjects.StoryDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591