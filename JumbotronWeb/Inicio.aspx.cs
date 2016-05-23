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
    protected void rpt_Viajes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "Comprar")
        //{
        //    int id = Convert.ToInt32(e.CommandArgument);

        //    Viaje v = GestorViaje.BuscarPorId(id);
        //    if (v != null)
        //    {
        //        ItemCarrito ic = new ItemCarrito()
        //        {
        //            idArticulo = a.IdArticulo,
        //            Descripcion = a.Descripcion,
        //            PrecioUnitario = a.Precio,
        //            Cantidad = 1
        //        };


        //        List<ItemCarrito> carrito = new List<ItemCarrito>();

        //        if (Session["Carrito"] != null)
        //        {
        //            carrito = (List<ItemCarrito>)Session["Carrito"];
        //        }

        //        carrito.Add(ic);

        //        Session["Carrito"] = carrito;

        //        Response.Redirect("SuCompra.aspx");

        //    }

        //}
        //else if (e.CommandName == "Ver")
        //{
        //    int idAtrticulo = Convert.ToInt32(e.CommandArgument);
        //    //formas de navegar entre webs: 3:
        //    //hipervinculo (pero acá el usuario decide a dónde quiere ir)
        //    //1)Response.redirect(url a la cual quiero ir)
        //    //2) Server.transfer (url)
        //    //Server.Execute()

        //    //diffs:
        //    //1: desv: voy y vuelvo.. mucho tiempo
        //    //1: ventaja: no hay contexto heredado(??)

        //    //2: es más rápido porq no hay ida y vuelta

        //    Response.Redirect(string.Format("DetalleArticulo.aspx?idarticulo={0}", idAtrticulo));

        //}
    }
}