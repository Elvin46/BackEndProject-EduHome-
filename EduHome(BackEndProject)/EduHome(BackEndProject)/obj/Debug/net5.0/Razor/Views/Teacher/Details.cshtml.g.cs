#pragma checksum "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a7214823c2587595452d2d0e7bb7d7643d2f39e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Details), @"mvc.1.0.view", @"/Views/Teacher/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a7214823c2587595452d2d0e7bb7d7643d2f39e", @"/Views/Teacher/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22a3d0111e25205e90ab2c2062d84fa3844eaa2a", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("teacher"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
Write(await Component.InvokeAsync("Banner"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
<!-- Teacher Start -->
<div class=""teacher-details-area pt-150 pb-60"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-5 col-sm-5 col-xs-12"">
                <div class=""teacher-details-img"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4a7214823c2587595452d2d0e7bb7d7643d2f39e4592", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 365, "~/img/teacher/", 365, 14, true);
#nullable restore
#line 12 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
AddHtmlAttributeValue("", 379, Model.Image, 379, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("  \r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-7 col-sm-7 col-xs-12\">\r\n                <div class=\"teacher-details-content ml-50\">\r\n                    <h2>");
#nullable restore
#line 17 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h5>");
#nullable restore
#line 18 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                   Write(Model.Profession);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h4>about me</h4>\r\n                    ");
#nullable restore
#line 20 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
               Write(Html.Raw(Model.About));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <ul>\r\n                        <li><span>degree: </span>");
#nullable restore
#line 22 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                            Write(Model.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li><span>experience: </span>");
#nullable restore
#line 23 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                Write(Model.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li><span>hobbies: </span>");
#nullable restore
#line 24 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                             Write(Model.Hobbies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li><span>faculty: </span>");
#nullable restore
#line 25 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                             Write(Model.Faculty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-3 col-sm-4"">
                <div class=""teacher-contact"">
                    <h4>contact information</h4>
                    <p><span>mail me : </span>");
#nullable restore
#line 34 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                         Write(Model.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><span>make a call : </span>");
#nullable restore
#line 35 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                             Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><span>skype : </span>");
#nullable restore
#line 36 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                       Write(Model.Skype);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <ul>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 1569, "\"", 1594, 1);
#nullable restore
#line 38 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue("", 1576, Model.FacebookUrl, 1576, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 1671, "\"", 1697, 1);
#nullable restore
#line 39 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue("", 1678, Model.PinterestUrl, 1678, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 1775, "\"", 1800, 1);
#nullable restore
#line 40 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue("", 1782, Model.LinkedinUrl, 1782, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-linkedin\"></i></a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 1877, "\"", 1901, 1);
#nullable restore
#line 41 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue("", 1884, Model.TwitterUrl, 1884, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""zmdi zmdi-twitter""></i></a></li>
                    </ul>
                </div>
            </div>
            <div class=""col-md-9 col-sm-8"">
                <div class=""skill-area"">
                    <h4>skills</h4>
                </div>  
                <div class=""skill-wrapper"">     
                    <div class=""row"">
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>language</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 2561, "\"", 2698, 11);
            WriteAttributeValue("", 2569, "width:", 2569, 6, true);
#nullable restore
#line 55 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue(" ", 2575, Model.LanguagePercent, 2576, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2598, "%;", 2598, 2, true);
            WriteAttributeValue(" ", 2600, "visibility:", 2601, 12, true);
            WriteAttributeValue(" ", 2612, "visible;", 2613, 9, true);
            WriteAttributeValue(" ", 2621, "animation-duration:", 2622, 20, true);
            WriteAttributeValue(" ", 2641, "1.5s;", 2642, 6, true);
            WriteAttributeValue(" ", 2647, "animation-delay:", 2648, 17, true);
            WriteAttributeValue(" ", 2664, "1.2s;", 2665, 6, true);
            WriteAttributeValue(" ", 2670, "animation-name:", 2671, 16, true);
            WriteAttributeValue(" ", 2686, "fadeInLeft;", 2687, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 56 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                          Write(Model.LanguagePercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>team leader</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 3312, "\"", 3451, 11);
            WriteAttributeValue("", 3320, "width:", 3320, 6, true);
#nullable restore
#line 65 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue(" ", 3326, Model.TeamLeaderPercent, 3327, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3351, "%;", 3351, 2, true);
            WriteAttributeValue(" ", 3353, "visibility:", 3354, 12, true);
            WriteAttributeValue(" ", 3365, "visible;", 3366, 9, true);
            WriteAttributeValue(" ", 3374, "animation-duration:", 3375, 20, true);
            WriteAttributeValue(" ", 3394, "1.5s;", 3395, 6, true);
            WriteAttributeValue(" ", 3400, "animation-delay:", 3401, 17, true);
            WriteAttributeValue(" ", 3417, "1.2s;", 3418, 6, true);
            WriteAttributeValue(" ", 3423, "animation-name:", 3424, 16, true);
            WriteAttributeValue(" ", 3439, "fadeInLeft;", 3440, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 66 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                          Write(Model.TeamLeaderPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>development</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 4067, "\"", 4207, 11);
            WriteAttributeValue("", 4075, "width:", 4075, 6, true);
#nullable restore
#line 75 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue(" ", 4081, Model.DevelopmentPercent, 4082, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4107, "%;", 4107, 2, true);
            WriteAttributeValue(" ", 4109, "visibility:", 4110, 12, true);
            WriteAttributeValue(" ", 4121, "visible;", 4122, 9, true);
            WriteAttributeValue(" ", 4130, "animation-duration:", 4131, 20, true);
            WriteAttributeValue(" ", 4150, "1.5s;", 4151, 6, true);
            WriteAttributeValue(" ", 4156, "animation-delay:", 4157, 17, true);
            WriteAttributeValue(" ", 4173, "1.2s;", 4174, 6, true);
            WriteAttributeValue(" ", 4179, "animation-name:", 4180, 16, true);
            WriteAttributeValue(" ", 4195, "fadeInLeft;", 4196, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 76 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                          Write(Model.DevelopmentPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>design</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 4819, "\"", 4954, 11);
            WriteAttributeValue("", 4827, "width:", 4827, 6, true);
#nullable restore
#line 85 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue(" ", 4833, Model.DesignPercent, 4834, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4854, "%;", 4854, 2, true);
            WriteAttributeValue(" ", 4856, "visibility:", 4857, 12, true);
            WriteAttributeValue(" ", 4868, "visible;", 4869, 9, true);
            WriteAttributeValue(" ", 4877, "animation-duration:", 4878, 20, true);
            WriteAttributeValue(" ", 4897, "1.5s;", 4898, 6, true);
            WriteAttributeValue(" ", 4903, "animation-delay:", 4904, 17, true);
            WriteAttributeValue(" ", 4920, "1.2s;", 4921, 6, true);
            WriteAttributeValue(" ", 4926, "animation-name:", 4927, 16, true);
            WriteAttributeValue(" ", 4942, "fadeInLeft;", 4943, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 86 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                          Write(Model.DesignPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>innovation</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 5565, "\"", 5704, 11);
            WriteAttributeValue("", 5573, "width:", 5573, 6, true);
#nullable restore
#line 95 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue(" ", 5579, Model.InnovationPercent, 5580, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5604, "%;", 5604, 2, true);
            WriteAttributeValue(" ", 5606, "visibility:", 5607, 12, true);
            WriteAttributeValue(" ", 5618, "visible;", 5619, 9, true);
            WriteAttributeValue(" ", 5627, "animation-duration:", 5628, 20, true);
            WriteAttributeValue(" ", 5647, "1.5s;", 5648, 6, true);
            WriteAttributeValue(" ", 5653, "animation-delay:", 5654, 17, true);
            WriteAttributeValue(" ", 5670, "1.2s;", 5671, 6, true);
            WriteAttributeValue(" ", 5676, "animation-name:", 5677, 16, true);
            WriteAttributeValue(" ", 5692, "fadeInLeft;", 5693, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 96 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                          Write(Model.InnovationPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>communication</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 6322, "\"", 6464, 11);
            WriteAttributeValue("", 6330, "width:", 6330, 6, true);
#nullable restore
#line 105 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
WriteAttributeValue(" ", 6336, Model.CommunicationPercent, 6337, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6364, "%;", 6364, 2, true);
            WriteAttributeValue(" ", 6366, "visibility:", 6367, 12, true);
            WriteAttributeValue(" ", 6378, "visible;", 6379, 9, true);
            WriteAttributeValue(" ", 6387, "animation-duration:", 6388, 20, true);
            WriteAttributeValue(" ", 6407, "1.5s;", 6408, 6, true);
            WriteAttributeValue(" ", 6413, "animation-delay:", 6414, 17, true);
            WriteAttributeValue(" ", 6430, "1.2s;", 6431, 6, true);
            WriteAttributeValue(" ", 6436, "animation-name:", 6437, 16, true);
            WriteAttributeValue(" ", 6452, "fadeInLeft;", 6453, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 106 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
                                                          Write(Model.CommunicationPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>   
                </div>     
            </div>
        </div>
    </div>
</div>
<!-- Teacher End -->
");
#nullable restore
#line 118 "C:\Users\HP\Desktop\BackEndProject-EduHome-\EduHome(BackEndProject)\EduHome(BackEndProject)\Views\Teacher\Details.cshtml"
Write(await Component.InvokeAsync("Subscribe"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; }
    }
}
#pragma warning restore 1591
