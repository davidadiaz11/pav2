﻿using System;
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
        mensaje(grilla_compra.SelectedIndex.ToString());
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

    private int calcularTotal()
    {
        int total = 0;

        foreach (GridViewRow rowItem in grilla_compra.Rows)
        {
            total += Convert.ToInt32(rowItem.Cells[7].Text);
        }
        return total;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (grilla_compra.SelectedRow == null)
            mensaje("Debe seleccionar un viaje");

        else
        {
            List<Paquete> lista = (List<Paquete>)Session["Compra"];
            lista.RemoveAt(grilla_compra.SelectedRow.RowIndex);
            Session["Compra"] = lista;
            cargarGrilla();
        }
    }

    public void mensaje(string msj)
    {
        lbl_mensaje.Text = msj;
    }
    protected void grilla_compra_SelectedIndexChanged(object sender, EventArgs e)
    {
        mensaje(grilla_compra.SelectedIndex.ToString());
        mensaje(GestorCompra.BuscarDestinosPaquete(grilla_compra.SelectedIndex));
        
        
    }


    protected void btnComprar_Click(object sender, EventArgs e)
    {
        mensaje("EL NENE ESTÁ BIEN");
    }
}