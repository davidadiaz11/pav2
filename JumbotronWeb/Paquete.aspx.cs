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
            //no funciona
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

            //descuenta para cada viaje el cupo disponible
            //no se debe llamar acá, debe ser llamado en la transacción. 
            //es decir tampoco llamado sino q tiene q usar esas instrucciones sql dentro de una transaccion
            //GestorViaje.descontarCupo((List<ItemPaquete>)GridView1.DataSource);

            //se debe llamar a un método que ponga en "no disponible" a aquellos viajes con cupo=0
            //Esto también debería hacerse en la transaccion
            //GestorViaje.actualizarDisponibles();

            //graba el paquete con sus detalles de paquete 
            // graba en viajexPaquete
            Paquete p = new Paquete();
            p.id = GestorPaquete.obtenerUltimoId();
            p.items = (List<ItemPaquete>)GridView1.DataSource;
            p.descripcion = "Paquete del usuario: ";
            p.fechaLlegada = Convert.ToDateTime("01/01/2000");
            p.fechaSalida = Convert.ToDateTime("01/01/2000");
            p.precio = 9;
            p.promocion = 7;
            //creo que este método debe ser llamado desde Compra.aspx, q es cuando se realiza efectivamente la compra
            //GestorPaquete.grabar(p);    

            //Con el boton comprar pasamos a la compra 
            List<Paquete> compra = new List<Paquete>();
            if (Session["Compra"] != null)
                compra = (List<Paquete>)Session["Compra"];
            p.id = p.id + compra.Count;
            compra.Add(p);
            Session["Compra"] = compra;
            Response.Redirect("Compra.aspx");
            //la Copmpra tendra un cliente asociado, un id, modo compra(efectivo ó tarjeta) y una fecha

            //la compra está compuesta por paquetes de ese usuario:
            //los detalles de Compra tendran un pauqte como item con un precio, cant de viajes

            //las tablas que se modifican son paquete, detallepauete, viaje, jviajeXpaquete, Compra y dettaleCompraç

            //en la grilla habrá un textbox q te permite modificar la cantidad
        }
            


    }
    protected void btnSubTotales_Click(object sender, EventArgs e)
    {
        //calcula subtotales de los detalles y total del paqute y contamos cuantos viajes hay
        int total;
        calcularSubtotales(out total);
    }

    private void calcularSubtotales(out int total)
    {
        total = 0;

        foreach (GridViewRow rowItem in GridView1.Rows)
        {
            total += Convert.ToInt32(rowItem.Cells[7].Text);
        }
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