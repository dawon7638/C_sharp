#pragma checksum "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UsersView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54744e0ea5f31dd519a7fbedd0fa6620e97068d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UsersView), @"mvc.1.0.view", @"/Views/Home/UsersView.cshtml")]
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
#line 1 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\_ViewImports.cshtml"
using view_models_fun;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UsersView.cshtml"
using view_models_fun.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54744e0ea5f31dd519a7fbedd0fa6620e97068d8", @"/Views/Home/UsersView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c64da30d0fc703bd5c829cab5185bfabfc48056", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UsersView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h2>Here are some Users!</h2>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UsersView.cshtml"
     foreach (var name in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 10 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UsersView.cshtml"
  Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 11 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UsersView.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
