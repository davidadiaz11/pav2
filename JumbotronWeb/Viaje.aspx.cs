using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Viajewf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            rpt_Paises.DataSource = GestorPais.BuscarTodos();
            rpt_Paises.DataBind();
            int? id = null;
            if (Request.QueryString["id"] != null)
                id = Convert.ToInt32(Request.QueryString["id"]);
            rpt_Viajes.DataSource = GestorViaje.BuscarPorPais(id);
            rpt_Viajes.DataBind();
        }
    }

    protected int calcularPrecioTotal(int precio, int cantidad)
    {
        return precio * cantidad;
    }
    protected void rpt_Viajes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Comprar")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            Viaje v = GestorViaje.buscarPorId(id, false);
            ItemPaquete ip = new ItemPaquete();
            if (v != null)
            {
                ip.id = v.id;
                ip.hotel = v.hotel;
                ip.hotel_descripcion=GestorViaje.obtenerDescripcion("Hotel", v.id);
                ip.precioUnitario = v.precio;
                ip.fechaSalida = v.fechaSalida;
                ip.destino = v.destino;
                ip.destino_descripcion = GestorViaje.obtenerDescripcion("Destino", v.id);
                ip.cantidad = 1;
                //ip.precioTotal = calcularPrecioTotal(ip.precioUnitario, ip.cantidad);
            };

            List<ItemPaquete> paquete = new List<ItemPaquete>();
            if (Session["Paquete"] != null)
                paquete = (List<ItemPaquete>)Session["Paquete"];

            paquete.Add(ip);
            Session["Paquete"] = paquete;
            Response.Redirect("Paquete.aspx");

        }
        else if (e.CommandName == "Ver")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect(string.Format("DetalleViaje.aspx?id={0}", id));
        }
    }
}