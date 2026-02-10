using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T.Utilizadores.Codigo
{
    public partial class RemoverUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            try
            {
                if (Request["id"] == null)
                    Response.Redirect("~/Utilizadores/Codigo/gerir.aspx");
                int id = int.Parse(Request["id"].ToString());
                Classes.Utilizadores uti = new Classes.Utilizadores();

                DataTable dados = uti.devolveDadosUtilizador(id);

                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("O utilizador não existe");
                }

                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbId.Text = dados.Rows[0]["id"].ToString();
            }

            catch
            {
                Response.Redirect("~/Utilizadores/Codigo/gerir.aspx");
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            Classes.Utilizadores uti = new Classes.Utilizadores();

            uti.removerUtilizador(id);
            Response.Redirect("~/Utilizadores/Codigo/gerir.aspx");
        }
    }
}