using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                AtualizarDDMarcas();
            }
        }
        //Atualiza os elementos da DD
        private void AtualizarDDMarcas()
        {
            dd_marcas.Items.Add(new ListItem("Apple", "2"));
        }

        protected void dd_marcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd_modelos.Items.Clear();
            //se escolheu hp (hp M1;hp M2)
            if (dd_marcas.SelectedValue=="0")
            {
                dd_modelos.Items.Add(new ListItem("hp M1"));
                dd_modelos.Items.Add(new ListItem("hp M2"));
            }
            //se escolheu asus (asus M1;asus M2)
            else if (dd_marcas.SelectedValue == "1")
            {
                dd_modelos.Items.Add(new ListItem("asus M1"));
                dd_modelos.Items.Add(new ListItem("asus M2"));
            }
            //se escolheu apple (maçã;batata)
            else if (dd_marcas.SelectedValue == "2")
            {
                dd_modelos.Items.Add(new ListItem("maçã"));
                dd_modelos.Items.Add(new ListItem("batata"));
            }
        }
    }
}