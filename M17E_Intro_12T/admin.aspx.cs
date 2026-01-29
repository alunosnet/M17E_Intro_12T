using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificar se o utilizador está autenticado
            if (Session["perfil"] == null)
                Response.Redirect("login.aspx");
            //verificar o perfil do utilizador
            if (Session["perfil"].ToString()!="0")
                Response.Redirect("login.aspx");
            //verificar o ip e o useragent
            if (Session["ip"].ToString() != Request.UserHostAddress || 
                Session["useragente"].ToString() != Request.UserAgent)
            {
                bt_logout_Click(sender, e);
            }
        }

        protected void bt_logout_Click(object sender, EventArgs e)
        {
            //limpar dos dados de sessão
            Session.Clear();
            //libertar a sessão
            Session.Abandon();
            //redirecionar para uma página publica
            Response.Redirect("login.aspx");
        }
    }
}