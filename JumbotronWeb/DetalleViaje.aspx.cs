using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetalleViaje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        int? pais = null ;
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            pais = GestorViaje.recuperarPais(id);
        }
        rpt_Viajes.DataSource = GestorViaje.BuscarPorPais(pais);
        rpt_Viajes.DataBind();
    }
}