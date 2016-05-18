using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity != null)
        {
            string usuario = Page.User.Identity.Name;
            bool EsAdministrador = Page.User.IsInRole("Administradores");

            //mnuHoteles.Visible = Page.User.IsInRole("pasajeros");
            //mnuAcercaDe.Visible = Page.User.IsInRole("pasajeros") || Page.User.IsInRole("administradores");
        }
        
        
    }
}
