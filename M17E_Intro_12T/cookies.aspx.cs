using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17E_Intro_12T
{
    public partial class cookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ler os cookies do browser
            HttpCookie temp = Request.Cookies["12T_Cookie"];
            //se existir o cookie 12T_Cookie esconder a div
            if (temp != null)
                div_aviso.Visible = false;
        }
    }
}