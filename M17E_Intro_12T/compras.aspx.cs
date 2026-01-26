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

        protected void bt_comprar_Click(object sender, EventArgs e)
        {
            //validação dos dados
            try
            {
                //nome
                string nome = tb_nome.Text;
                if (string.IsNullOrEmpty(nome) || nome.Length < 5)
                    throw new Exception("O campo nome é obrigatório preencher com pelo menos 5 letras");
                //email
                string email=tb_email.Text;
                if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
                    throw new Exception("O email não é válido.");
                //data nascimento
                DateTime data = c_data_nasc.SelectedDate;
                TimeSpan idade = DateTime.Now - data;
                if (idade.TotalDays / 365 < 18)
                    throw new Exception("Tem de ter pelo menos 18 anos.");
                //marca
                if (dd_marcas.SelectedIndex <= 0)
                    throw new Exception("Tem de escolher uma marca de computador.");
                //modelo
                if (dd_modelos.SelectedIndex < 0)
                    throw new Exception("Tem de escolher um modelo de computador.");
                //processador
                if (rb_amd.Checked == false && rb_intel.Checked == false && rb_outro.Checked == false)
                    throw new Exception("Tem de selecionar um processador.");
                //condições
                if (cb_aceitar.Checked == false)
                    throw new Exception("Tem de aceitar as condições da compra.");
                //guardar a imagem
                //existe ficheiro?
                if (fu_foto.FileName == "")
                    throw new Exception("Tem de enviar uma foto");
                //validação do tipo de ficheiro
                if (fu_foto.PostedFile.ContentType != "image/jpeg" &&
                    fu_foto.PostedFile.ContentType != "image/png")
                    throw new Exception("O tipo de ficheiro não é válido.");
                //validação do tamanho do ficheiro
                if (fu_foto.PostedFile.ContentLength==0 || 
                    fu_foto.PostedFile.ContentLength>50000000)
                {
                    throw new Exception("O tamanho do ficheiro não pode ser 0 nem superior a 50MB");
                }
                //guardar no servidor
            }
            catch (Exception ex)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + ex.Message;
            }
        }
    }
}