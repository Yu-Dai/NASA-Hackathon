#pragma checksum "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92801323efa8180ae95ff8fa8a8923f0dfa76c45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Level3), @"mvc.1.0.view", @"/Views/Home/Level3.cshtml")]
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
#line 1 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\_ViewImports.cshtml"
using NASA_Hackathon;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\_ViewImports.cshtml"
using NASA_Hackathon.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92801323efa8180ae95ff8fa8a8923f0dfa76c45", @"/Views/Home/Level3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566735061923bc7f239313bf5aae59c3809d44af", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Level3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NASA_Hackathon.Models.Level3Model>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/webcamjs/webcam.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
  
    ViewBag.Title = "Level3";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Level 3</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
                            

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script type=\"text/javascript\" src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92801323efa8180ae95ff8fa8a8923f0dfa76c454863", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">
    $(function () {
        Webcam.set({
            width: 240,
            height: 360,
            image_format: 'jpeg',
            jpeg_quality: 100
        });

        Webcam.set('constraints', {
            facingMode: ""environment""
        });
        Webcam.attach(""#idwebcam"")

        //截圖
        $(""#btncapture"").click(function () {
            Webcam.snap(function (data_uri) {
                $(""#idcaptured"")[0].src = data_uri;
            });
        });
    });
</script>

<table border=""0"" cellpadding=""0"" cellspacing=""0"" data-role=""table"" class=""ui-responsive"">
    <tr>
        <th align=""center"">Live Camera</th>
        <th align=""center"">Captured Picture</th>
    </tr>
    <tr>
        <td style=""position: relative"">
            <div id=""idwebcam""></div>
            <span style=""position: absolute; top: 110px; left: 20px; color:red; font-weight:bold;"">將紅框對準試紙區</span>
            <div style=""position: absolute; top: 135px; left:");
            WriteLiteral(@" 20px; border: 5px solid red; width: 200px; height: 60px""></div>
        </td>
        <td style=""position: relative"">
            <img style=""position: absolute; top: 0px; left: 0px; clip: rect(135px 220px 195px 20px);"" id=""idcaptured"" />
        </td>
    </tr>
    <tr>
        <td align=""center"">
            <br>
            <input type=""button"" id=""btncapture"" value=""截取"" class=""btn btn-primary"" />
        </td>
        <td align=""center"">
            <br>
            ");
#nullable restore
#line 62 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
       Write(Html.TextBoxFor(model => model.imageBuffer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <input type=\"submit\" id=\"btncalculate\" name=\"btnSubmit\" value=\"計算\" class=\"btn btn-primary\" />\r\n        </td>\r\n    </tr>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NASA_Hackathon.Models.Level3Model> Html { get; private set; }
    }
}
#pragma warning restore 1591
