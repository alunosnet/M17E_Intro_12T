using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ler da url o parâmetro resultado
            if (Request.QueryString["resultado"] != null)
            {
                int resultado = 0;
                bool converteu = int.TryParse(Request.QueryString["resultado"],
                                                   out resultado);
                if (converteu)
                {
                    div_resultado.InnerText = "Resultado = " + resultado;
                }
                else
                {
                    Response.Write("<script>alert('O valor não é válido.')</script>");
                }
            }
            else
            {
                //Response.Write("<script>alert('Não existe o parâmetro resultado.')</script>");
                //Redirecionar para a página index.aspx
                // e mostrar uma mensagem de erro!
                Response.Redirect("index.aspx?erro=1");
            }
        }
    }
}