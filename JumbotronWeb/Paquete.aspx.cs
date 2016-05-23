using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paquete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = (List<ItemPaquete>)Session["Paquete"];
        GridView1.DataBind();
    }
    public void mensaje(string msj)
    {
        lbl_mensaje.Text = msj;
    }
    public void accion(string mensaje)
    {
        lblAccion.Text = mensaje;
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["GvDatosOrden"] = e.SortExpression;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Viaje.aspx");
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
         if (GridView1.SelectedRow == null)
            mensaje("Debe seleccionar un viaje");

        else
        {
             
        }   
    }
}