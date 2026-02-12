using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class recuperarpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                //verificar se tem o token url
                if (Request.QueryString["token"] == null)
                    throw new Exception("erro");
                string token=Server.UrlDecode(Request.QueryString["token"]);
                //verificar se definiu uma password válida
                if (tb_palavra_passe.Text=="")
                    throw new Exception("erro");
                string password = tb_palavra_passe.Text;
                //guardar a nova palavra passe
                Classes.Utilizadores utilizador = new Classes.Utilizadores();
                utilizador.atualizarPassword(token, password);
            }catch { }
            //redirecionar para login
            Response.Redirect("login.aspx");
        }
    }
}