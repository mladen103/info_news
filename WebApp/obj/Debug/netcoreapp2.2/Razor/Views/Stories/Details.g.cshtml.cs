#pragma checksum "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b504fe16d74079f1f497d8a2b22b052c3cc8c9c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stories_Details), @"mvc.1.0.view", @"/Views/Stories/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stories/Details.cshtml", typeof(AspNetCore.Views_Stories_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b504fe16d74079f1f497d8a2b22b052c3cc8c9c9", @"/Views/Stories/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Stories_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DataTransferObjects.StoryDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(94, 176, true);
            WriteLiteral("\r\n<div>\r\n    <h4>Story Details</h4>\r\n    <hr />\r\n\r\n    <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"thumbnail\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 270, "\"", 333, 2);
            WriteAttributeValue("", 276, "/uploads/", 276, 9, true);
#line 14 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
WriteAttributeValue("", 285, Html.DisplayFor(modelItem => Model.PicturePath), 285, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 334, "\"", 381, 1);
#line 14 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
WriteAttributeValue("", 340, Html.DisplayFor(modelItem => Model.Name), 340, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(382, 108, true);
            WriteLiteral(">\r\n                    <hr />\r\n                    <div class=\"caption\">\r\n                        <h3>Name: ");
            EndContext();
            BeginContext(491, 40, false);
#line 17 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                             Write(Html.DisplayFor(modelItem => Model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(531, 74, true);
            WriteLiteral("</h3>\r\n                        <hr />\r\n                        <p>Active: ");
            EndContext();
            BeginContext(606, 44, false);
#line 19 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                              Write(Html.DisplayFor(modelItem => Model.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(650, 95, true);
            WriteLiteral("</p>\r\n                        <hr />\r\n                        <p>\r\n                            ");
            EndContext();
            BeginContext(746, 47, false);
#line 22 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(793, 137, true);
            WriteLiteral("\r\n                        </p>\r\n                        <hr />\r\n                        <p>\r\n                            Journalists:\r\n\r\n");
            EndContext();
#line 28 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                             foreach (var journalist in Model.Journalists)
                            {
                                

#line default
#line hidden
            BeginContext(1070, 20, false);
#line 30 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                           Write(journalist.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1097, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1107, 19, false);
#line 30 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                                                                Write(journalist.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1133, 3, true);
            WriteLiteral(" | ");
            EndContext();
#line 30 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
                                                                                                          
                            }

#line default
#line hidden
            BeginContext(1176, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1214, 183, true);
            WriteLiteral("\r\n\r\n                        </p>\r\n                        <hr />\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        \r\n    </div>\r\n\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1398, 55, false);
#line 45 "C:\Users\Mladen\source\repos\info_news\WebApp\Views\Stories\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new {  id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1453, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1461, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b504fe16d74079f1f497d8a2b22b052c3cc8c9c98365", async() => {
                BeginContext(1483, 12, true);
                WriteLiteral("Back to List");
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
            BeginContext(1499, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DataTransferObjects.StoryDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
