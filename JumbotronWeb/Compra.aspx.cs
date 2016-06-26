using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Compra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarGrilla();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //TODO 500 se debería limpiar antes el session para q al volver no este el paquete recién agregado?
        Session["Paquete"] = new List<ItemPaquete>();
        Response.Redirect("Paquete.aspx");
    }

    private void cargarGrilla()
    {
        grilla_compra.DataSource = (List<Paquete>)Session["Compra"];
        grilla_compra.DataBind();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }
}