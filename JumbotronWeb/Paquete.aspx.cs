﻿using System;
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
    protected void btnComprar_Click(object sender, EventArgs e)
    {
        //cuando se compra se debe validar que la cantidad que se esta comprando sea menor al cupo disponble
        //descuenta para cada viaje el cupo disponiblee 
        //graba el paquete con sus detalles de paquete 
        // graba en viajexPaquete 
        //Con el boton comprar pasamos a la compra 
        //la Copmpra tendra un cliente asociado un id, modo compra(efectivo ó tarjeta) y una fecha
        //los detalles de Compra tendran un pauqte como item con un precio, cant de viajes

        //las tablas que se modifican son paquete, detallepauete, viaje, jviajeXpaquete, Compra y dettaleCompraç

        //en la grilla habrá un textbox q te permite modificar la cantidad
    }
    protected void btnSubTotales_Click(object sender, EventArgs e)
    {
        //calcula sib totales de los detalles y total del oaqute y contamos cuantos viajes hay
    }
}