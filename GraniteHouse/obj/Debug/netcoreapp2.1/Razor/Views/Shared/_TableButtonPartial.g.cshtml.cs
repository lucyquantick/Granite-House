#pragma checksum "C:\Users\lucyq\source\repos\Granite House\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa5ddf3e19765331a3932a18788e8658622b5201"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TableButtonPartial), @"mvc.1.0.view", @"/Views/Shared/_TableButtonPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_TableButtonPartial.cshtml", typeof(AspNetCore.Views_Shared__TableButtonPartial))]
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
#line 1 "C:\Users\lucyq\source\repos\Granite House\GraniteHouse\GraniteHouse\Views\_ViewImports.cshtml"
using GraniteHouse;

#line default
#line hidden
#line 2 "C:\Users\lucyq\source\repos\Granite House\GraniteHouse\GraniteHouse\Views\_ViewImports.cshtml"
using GraniteHouse.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa5ddf3e19765331a3932a18788e8658622b5201", @"/Views/Shared/_TableButtonPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"add87ae52faa7df67fbebca5d3c39a845d0e03fe", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TableButtonPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(133, 111, true);
            WriteLiteral("\r\n\r\n<td style=\"width:200px\">\r\n\t<div class=\"btn-group\" role=\"group\">\r\n\t\t<a type=\"button\" class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 244, "\"", 277, 1);
#line 8 "C:\Users\lucyq\source\repos\Granite House\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 251, Url.Action("Edit/"+Model), 251, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(278, 53, true);
            WriteLiteral(">Edit</a>\r\n\t\t<a type=\"button\" class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 331, "\"", 367, 1);
#line 9 "C:\Users\lucyq\source\repos\Granite House\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 338, Url.Action("Details/"+Model), 338, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(368, 55, true);
            WriteLiteral(">Details</a>\r\n\t\t<a type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 423, "\"", 458, 1);
#line 10 "C:\Users\lucyq\source\repos\Granite House\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 430, Url.Action("Delete/"+Model), 430, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(459, 27, true);
            WriteLiteral(">Delete</a>\r\n\t</div>\r\n</td>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
