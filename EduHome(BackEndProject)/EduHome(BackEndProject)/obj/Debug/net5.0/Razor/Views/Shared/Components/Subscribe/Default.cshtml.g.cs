#pragma checksum "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b84269c9f530c3e8d67af428cbc05a2f54475190"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Subscribe_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Subscribe/Default.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\_ViewImports.cshtml"
using EduHome_BackEndProject_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\_ViewImports.cshtml"
using EduHome_BackEndProject_.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\_ViewImports.cshtml"
using EduHome_BackEndProject_.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84269c9f530c3e8d67af428cbc05a2f54475190", @"/Views/Shared/Components/Subscribe/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22a3d0111e25205e90ab2c2062d84fa3844eaa2a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Subscribe_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
  
    SubscribeViewModel subscribeViewModel = Model;
    User user = subscribeViewModel.User;
    Subscribe subscribe = subscribeViewModel.Subscribe;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Subscribe Start -->
<div class=""subscribe-area pt-60 pb-70"" >
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8 col-md-offset-2"">
                <div class=""subscribe-content section-title text-center"">
                    <h2>");
#nullable restore
#line 12 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
                   Write(subscribe.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <p>");
#nullable restore
#line 13 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
                  Write(subscribe.Subtitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"newsletter-form mc_embed_signup text-center\" id=\"subscribe-box\">\r\n");
#nullable restore
#line 16 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
                     if (user.IsSubscribed == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button id=\"subscribe\" class=\"default-btn\" ><span>subscribe</span></button>\r\n");
#nullable restore
#line 19 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button id=\"subscribe\" class=\"default-btn\" ><span>unsubscribe</span></button>\r\n");
#nullable restore
#line 23 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <input id=\"userId\"");
            BeginWriteAttribute("value", " value =\"", 1034, "\"", 1051, 1);
#nullable restore
#line 24 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Subscribe\Default.cshtml"
WriteAttributeValue("", 1043, user.Id, 1043, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" type=""hidden""/>
                    <!-- mailchimp-alerts Start -->
                    <div class=""mailchimp-alerts"">
                        <div class=""mailchimp-submitting""></div><!-- mailchimp-submitting end -->
                        <div class=""mailchimp-success""></div><!-- mailchimp-success end -->
                        <div class=""mailchimp-error""></div><!-- mailchimp-error end -->
                    </div>
                    <!-- mailchimp-alerts end -->
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Subscribe End -->

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
