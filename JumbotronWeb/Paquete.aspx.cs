using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paquetesw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Pone en "no disponible" a aquellos viajes con cupo=0, o que ya hayan partido
        //GestorViaje.actualizarDisponibles();
        cargarGrilla();
    }

    private void cargarGrilla()
    {
        GridView1.DataSource = (List<ItemPaquete>)Session["Paquete"];
        GridView1.DataBind();
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
            List<ItemPaquete> lista = (List<ItemPaquete>)Session["Paquete"];
            lista.RemoveAt(GridView1.SelectedRow.RowIndex);
            Session["Paquete"] = lista;
            cargarGrilla();
        }
    }

    private bool consultarCupo(out int? idSinCupo)
    {
        idSinCupo = null;
        int cantidad;
        int cupo;
        foreach (GridViewRow rowItem in GridView1.Rows)
        {

            cantidad = Convert.ToInt32(rowItem.Cells[5].Text);
            cupo = Convert.ToInt32(rowItem.Cells[8].Text);
            if (cantidad > cupo)
            {
                idSinCupo = Convert.ToInt32(rowItem.Cells[1].Text);
                return false;
            }
        }
        return true;
    }

    protected void btnComprar_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0 )
        {
            //cuando se compra se debe validar que la cantidad que se esta comprando sea menor al cupo disponble
            int? idSinCupo;
            if (!consultarCupo(out idSinCupo) && idSinCupo > 0)
            {
                mensaje("El viaje con id: " + idSinCupo + " no posee cupo suficiente.");
            }
            else
            {
                //descuenta para cada viaje el cupo disponible
                //las consultas sql de este método deben realizarse dentro de una transacción en GestorCompra
                //GestorViaje.descontarCupo((List<ItemPaquete>)GridView1.DataSource);

                Paquete p = new Paquete();
                p.items = (List<ItemPaquete>)GridView1.DataSource;
                p.descripcion = "Paquete del usuario: ";
                p.fechaLlegada = Convert.ToDateTime("01/01/2017");
                p.fechaSalida = Convert.ToDateTime("01/01/2017");
                p.precio = calcularTotal();
                p.promocion = 2;
            
                //graba en Paquete, en ViajeXPaquete y en PaquetexUsuario
                int idpaquete = GestorPaquete.grabar(p);    

                List<Paquete> compra = new List<Paquete>();
                if (Session["Compra"] != null)
                    compra = (List<Paquete>)Session["Compra"];
                p.id = idpaquete;
                compra.Add(p);
                Session["Compra"] = compra;
                Response.Redirect("Compra.aspx");

                //la Copmpra tendra un cliente asociado, un id, modo compra(efectivo ó tarjeta) y una fecha
                //la compra está compuesta por paquetes de ese usuario:
                //los detalles de Compra tendran un pauqte como item con un precio, cant de viajes
                //en la grilla habrá un textbox q te permite modificar la cantidad. NO LLEGAMOS A ESTO, TAMPOCO ES IMPORTANTE
            }
        }
    }

  

    private int calcularTotal()
    {
        int total = 0;

        foreach (GridViewRow rowItem in GridView1.Rows)
        {
            total += Convert.ToInt32(rowItem.Cells[7].Text);
        }
        return total;
    }


    public void mensaje(string msj)
    {
        lbl_mensaje.Text = msj;
    }
    public void accion(string mensaje)
    {
        lblAccion.Text = mensaje;
    }
}