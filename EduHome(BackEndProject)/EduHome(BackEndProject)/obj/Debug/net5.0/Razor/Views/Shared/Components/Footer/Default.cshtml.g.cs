#pragma checksum "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bd384f7b201aab3b29f5b6eacf82503b98c80fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\_ViewImports.cshtml"
using EduHome_BackEndProject_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\_ViewImports.cshtml"
using EduHome_BackEndProject_.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\_ViewImports.cshtml"
using EduHome_BackEndProject_.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bd384f7b201aab3b29f5b6eacf82503b98c80fa", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22a3d0111e25205e90ab2c2062d84fa3844eaa2a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bio>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<footer class=""footer-area"">
    <div class=""main-footer"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-4 col-sm-6 col-xs-12"">
                    <div class=""single-widget pr-60"">
                        <div class=""footer-logo pb-25"">
                            <a href=""index.html""><img");
            BeginWriteAttribute("src", " src=\"", 361, "\"", 387, 2);
            WriteAttributeValue("", 367, "img/logo/", 367, 9, true);
#nullable restore
#line 9 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 376, Model.Logo, 376, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""eduhome""></a>
                        </div>
                        <p>I must explain to you how all this mistaken idea of denoung pleure and praising pain was born and give you a coete account of the system. </p>
                        <div class=""footer-social"">
                            <ul>
                                <li><a");
            BeginWriteAttribute("href", " href=\"", 737, "\"", 762, 1);
#nullable restore
#line 14 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 744, Model.FacebookUrl, 744, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 847, "\"", 873, 1);
#nullable restore
#line 15 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 854, Model.PinterestUrl, 854, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 959, "\"", 984, 1);
#nullable restore
#line 16 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 966, Model.LinkedinUrl, 966, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-linkedin\"></i></a></li>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1069, "\"", 1093, 1);
#nullable restore
#line 17 "C:\Users\HP\source\repos\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 1076, Model.TwitterUrl, 1076, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""zmdi zmdi-twitter""></i></a></li>
                            </ul>    
                        </div>
                    </div>
                </div>
                <div class=""col-md-3 col-sm-6 col-xs-12"">
                    <div class=""single-widget"">
                        <h3>information</h3>
                        <ul>
                            <li><a href=""#"">addmission</a></li>
                            <li><a href=""#"">Academic Calender</a></li>
                            <li><a href=""event.html"">Event List</a></li>
                            <li><a href=""#"">Hostel &amp; Dinning</a></li>
                            <li><a href=""#"">TimeTable</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-md-2 col-sm-6 col-xs-12"">
                    <div class=""single-widget"">
                        <h3>useful links</h3>
                        <ul>
                            <li><a href=""course.html"">");
            WriteLiteral(@"our courses</a></li>
                            <li><a href=""about.html"">about us</a></li>
                            <li><a href=""teacher.html"">teachers &amp; faculty</a></li>
                            <li><a href=""#"">teams &amp; conditions</a></li>
                            <li><a href=""event.html"">our events</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-md-3 col-sm-6 col-xs-12"">
                    <div class=""single-widget"">
                        <h3>get in touch</h3>
                        <p>Your address goes here, Street<br>City, Roadno 785 New York</p>
                        <p>+880  548  986  898  87<br>+880  659  785  658  98</p>
                        <p>info@eduhome.com<br>www.eduhome.com</p>
                    </div>
                </div>
            </div>
        </div>
    </div>   
    <div class=""footer-bottom text-center"">
        <div class=""container"">
            <div class=""row"">");
            WriteLiteral("\r\n                <div class=\"col-xs-12\">\r\n                    <p>Copyright © <a href=\"#\" target=\"_blank\">HasTech</a> 2017. All Right Reserved By Hastech.</p>\r\n                </div> \r\n            </div>\r\n        </div>    \r\n    </div>\r\n</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bio> Html { get; private set; }
    }
}
#pragma warning restore 1591
