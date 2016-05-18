using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ctrl_login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (GestorUsuarios.VerificarUsuarioClave(ctrl_login.UserName, ctrl_login.Password))
            e.Authenticated = true;  // genera cookie de seguridad con datos del usuario (sin los roles)
        else
            e.Authenticated = false;
    }
}