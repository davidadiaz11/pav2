using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            int id = 1;
            if (Request.QueryString["id"] != null)
                id = Convert.ToInt32(Request.QueryString["id"]);
            rpt_Viajes.DataSource = GestorViaje.BuscarPorPais(id);
            rpt_Viajes.DataBind();
        }
    }
}