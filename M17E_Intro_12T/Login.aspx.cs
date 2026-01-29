using M17E_Intro_12T.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_login_Click(object sender, EventArgs e)
        {
            //validar os dados
            if (tb_email.Text=="" || tb_password.Text=="")
            {
                lb_erro.Text = "Login falhou. Tente novamente.";
                return;
            }
            //Verificar o login
            Utilizadores user = new Utilizadores();
            user.email=tb_email.Text;
            user.palavra_passe= tb_password.Text;
            if(user.VerificaLogin()==false)
            {
                lb_erro.Text = "Login falhou. Tente novamente.";
                return;
            }
            //iniciar sessão
            Session["email"] = user.email;
            Session["perfil"] = user.perfil;
            Session["id"] = user.id;
            Session["nome"] = user.nome;
            //guardar dados do utilizador/browser
            Session["ip"] = Request.UserHostAddress;
            Session["useragente"] = Request.UserAgent;
            //redirecionar o utilizador
            if (user.perfil == 0)
            {
                Response.Redirect("admin.aspx");
            }
            if (user.perfil == 1)
            {
                Response.Redirect("funcionario.aspx");
            }
        }
    }
}