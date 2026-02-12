using M17E_Intro_12T.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
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
            //Validar recaptcha
            //var resposta = Request.Form["g-Recaptcha-Response"];
            //var validou = ReCaptcha.Validate(resposta);
            //if (validou==false)
            //{
            //    lb_erro.Text = "Tem de provar que não é um robot.";
            //    return;
            //}
            //Verificar o login
            Classes.Utilizadores user = new Classes.Utilizadores();
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

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            /* Validar recaptcha
            var resposta = Request.Form["g-Recaptcha-Response"];
            var validou = ReCaptcha.Validate(resposta);
            if (validou == false)
            {
                lb_erro.Text = "Tem de provar que não é um robot.";
                return;
            }*/
            try
            {
                //validar o email
                if (tb_email.Text == "")
                    throw new Exception("Erro");
                string email = tb_email.Text;
                Classes.Utilizadores utilizadores = new Classes.Utilizadores();
                DataTable dados = utilizadores.devolveDadosUtilizador(email);
                if (dados==null || dados.Rows.Count!=1)
                    throw new Exception("Erro");

                //gerar o token
                Guid guid= Guid.NewGuid();
                string token=guid.ToString();
                utilizadores.recuperarPassword(email, token);
                //criar mensagem
                string mensagem = "Clique no link para recuperar a sua password.<br/>";
                mensagem += "<a href='https://" + Request.Url.Authority + "/recuperarpassword.aspx";
                mensagem += "?token=" + Server.UrlEncode(token) + "'>Clique aqui</a>";

                //enviar a mensagem por email
                string meuemail = ConfigurationManager.AppSettings["meu_email"];
                string minha_password = ConfigurationManager.AppSettings["password_meu_email"];
                Helper.enviarMail(meuemail, minha_password, email,
                    "Recuperação de palavra passe", mensagem);
            }
            catch (Exception ex)
            {

            }
            //mensagem ao utilizar
            lb_erro.Text = "Caso o email indicado seja válido recebeu uma mensagem para recuperação da sua palavra passe";
        }
    }
}