#pragma checksum "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1774946006e78f7246064d3c6bc7ec5de4e04b13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Eventos_Index), @"mvc.1.0.view", @"/Views/Eventos/Index.cshtml")]
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
#line 1 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\_ViewImports.cshtml"
using EventOrg2027;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\_ViewImports.cshtml"
using EventOrg2027.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1774946006e78f7246064d3c6bc7ec5de4e04b13", @"/Views/Eventos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9680cf2734324657ad4e92fb4c517643b3a6b2a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Eventos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventosListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size: 1vw"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
  
    ViewData["Title"] = "Lista De Eventos";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<header class=\"masthead2 text-center\">\n    <h1>");
#nullable restore
#line 8 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
   Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1>\n\n\n    <p>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1774946006e78f7246064d3c6bc7ec5de4e04b135273", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </p>\n    <table class=\"table\">\n\n        \n");
#nullable restore
#line 17 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
             foreach (var p in Model.Eventos)

            {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"cardeventos \">\n            <div class=\"card-body\">\n                <h5 class=\"card-title\" style=\"font-size: 1.5vw\">");
#nullable restore
#line 23 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                           Write(p.NomeEventos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                <h6 class=\"card-subtitle mb-2 text-muted\" style=\"font-size: 0.7vw\">");
#nullable restore
#line 24 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                                              Write(p.DataRealizacao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                <p class=\"card-text\" style=\"font-size: 0.9vw\">");
#nullable restore
#line 25 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                         Write(p.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p><buton style=\"font-size: 0.8vw\">Ver</buton></p>\n            </div>\n        </div>\n");
#nullable restore
#line 29 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"


            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\n\n    <nav class=\"mt-3\">\n        <ul class=\"pagination\">\n            <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1774946006e78f7246064d3c6bc7ec5de4e04b138452", async() => {
                WriteLiteral("First");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n\n");
#nullable restore
#line 38 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
              
                int initalPage = Model.Pagination.CurrentPage - PagingInfo.NUMBER_PAGES_SHOW_BEFORE_AFTER;
                if (initalPage < 1) initalPage = 1;

                int finalPage = Model.Pagination.CurrentPage + PagingInfo.NUMBER_PAGES_SHOW_BEFORE_AFTER;
                if (finalPage > Model.Pagination.TotalPages) finalPage = Model.Pagination.TotalPages;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 46 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
             for (int p = initalPage; p <= finalPage; p++)
            {
                if (p == Model.Pagination.CurrentPage)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item active\"><a class=\"page-link\" href=\"#\">");
#nullable restore
#line 50 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                                          Write(p);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 51 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1774946006e78f7246064d3c6bc7ec5de4e04b1311839", async() => {
#nullable restore
#line 54 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                                                                 Write(p);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                                                      WriteLiteral(p);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n");
#nullable restore
#line 55 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1774946006e78f7246064d3c6bc7ec5de4e04b1314641", async() => {
                WriteLiteral("Last");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\Marcelo Lopes\source\repos\EventOrg2027\EventOrg2027\Views\Eventos\Index.cshtml"
                                                                              WriteLiteral(Model.Pagination.TotalPages);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n        </ul>\n    </nav>\n</header>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventosListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
