#pragma checksum "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UserView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a6b7ed7d9a16649382912a72d0f7825b3ee5bec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserView), @"mvc.1.0.view", @"/Views/Home/UserView.cshtml")]
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
#line 1 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UserView.cshtml"
using view_models_fun.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a6b7ed7d9a16649382912a72d0f7825b3ee5bec", @"/Views/Home/UserView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c64da30d0fc703bd5c829cab5185bfabfc48056", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UserView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h2>Here is a User!</h2>\r\n    <p>");
#nullable restore
#line 6 "C:\Users\dawon\OneDrive\Desktop\coding_dojo\C#\asp\view-models-fun\Views\Home\UserView.cshtml"
  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
