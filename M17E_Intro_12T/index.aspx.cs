using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class index : System.Web.UI.Page
    {
        //Sempre executado em qualquer evento!
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se a url tem um parâmetro erro
            //http://localhost:index.aspx?erro=qq
            if (Request.QueryString["erro"]!=null)
            {
                Label3.Text = "Erro! Falta o parâmetro resultado.";
            }
            if (!IsPostBack)
            {
                tb_x.Text = "0";
                tb_y.Text = "0";
            }
        }

        protected void bt_somar_Click(object sender, EventArgs e)
        {
            int x, y;
            x = int.Parse(tb_x.Text);
            y=int.Parse(tb_y.Text);
            Label3.Text = (x+y).ToString();
        }

        protected void bt_resultado_Click(object sender, EventArgs e)
        {
            int x, y;
            x = int.Parse(tb_x.Text);
            y = int.Parse(tb_y.Text);
            int resultado = x + y;
            string url = "resultado.aspx?resultado=" + resultado;
            Response.Redirect(url);
            //Server.Transfer(url); //não atualiza a url no browser
        }

        protected void bt_cookies_Click(object sender, EventArgs e)
        {
            //Criar cookie
            HttpCookie novo = new HttpCookie("12T_Cookie");
            //Definir a data em que expira
            novo.Expires = DateTime.Now.AddDays(30);
            //definir o valor
            novo.Value = "Teste";
            //enviar para o browser
            Response.Cookies.Add(novo);
        }
    }
}