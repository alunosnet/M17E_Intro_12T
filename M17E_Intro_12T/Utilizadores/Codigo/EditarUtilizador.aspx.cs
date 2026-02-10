using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T.Utilizadores.Codigo
{
    public partial class EditarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //consultar a bd para recolher os dados do utilizador
            if (IsPostBack) return;
            try
            {
                if (Request["id"] == null)
                    Response.Redirect("~/Utilizadores/Codigo/gerir.aspx");
                int id = int.Parse(Request["id"].ToString());
                Classes.Utilizadores utilizador = new Classes.Utilizadores();
                DataTable dados = utilizador.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Utilizador não existe");
                }
                tbNome.Text = dados.Rows[0]["nome"].ToString();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Utilizadores/Codigo/gerir.aspx')", true);
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text.Trim();
                if (string.IsNullOrEmpty(nome) || nome.Length < 3)
                {
                    throw new Exception("O nome não é válido.");
                }

                int id = int.Parse(Request["id"].ToString());
                Classes.Utilizadores utilizador = new Classes.Utilizadores();
                utilizador.id = id;
                utilizador.nome = nome;
                utilizador.atualizarUtilizador();
            }
            catch (Exception error)
            {
                lbErro.Text = "Ocorreu um erro: " + error.Message;
                return;
            }
            lbErro.Text = "Utilizador atualizado com sucesso.";
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Utilizadores/Codigo/gerir.aspx')", true);
        }
    }
}