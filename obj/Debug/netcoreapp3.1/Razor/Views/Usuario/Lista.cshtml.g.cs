#pragma checksum "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a58a8283092e16eb41f52495b7ccb52b7f573ba2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Lista), @"mvc.1.0.view", @"/Views/Usuario/Lista.cshtml")]
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
#line 1 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\_ViewImports.cshtml"
using ATIVIDADE_2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\_ViewImports.cshtml"
using ATIVIDADE_2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a58a8283092e16eb41f52495b7ccb52b7f573ba2", @"/Views/Usuario/Lista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88eeb7e5b8265e4f803b80ae05e51cb95572ffb9", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Lista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
  
    ViewData["Title"] = "Listagem de usuários";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <td>Id</td>
            <td>Nome</td>
            <td>Login</td>
            <td>Senha</td>
            <td>Data de Nascimento</td>
            <td>Operações</td>
        </tr>
    </thead>



");
#nullable restore
#line 21 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
     foreach (Usuario u in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 24 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
           Write(u.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
           Write(u.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
           Write(u.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
           Write(u.Senha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
           Write(u.DataNascimento.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 620, "\"", 651, 2);
            WriteAttributeValue("", 627, "/Usuario/Editar?Id=", 627, 19, true);
#nullable restore
#line 30 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
WriteAttributeValue("", 646, u.Id, 646, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Alterar</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 684, "\"", 716, 2);
            WriteAttributeValue("", 691, "/Usuario/Remover?Id=", 691, 20, true);
#nullable restore
#line 31 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"
WriteAttributeValue("", 711, u.Id, 711, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Confirma excluir esse registro\');\">Excluir</a>\r\n\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 36 "A:\T.I-PROGRAMAÇÃO\TÉCNICO EM INFORMATICA PARA INTERNET - PSG\UC04-Estruturar e implementar banco de dados para aplicacoes web\ATIVIDADE_2\ATIVIDADE_2\Views\Usuario\Lista.cshtml"


    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
