using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformeViaje : System.Web.UI.Page
{
    string precio; 
    string cupo;
    int destino;

    public void Page_Load(object sender, EventArgs e)
    {
       

        cargarGrilla();
        cargarCombo();
    }

    public void Button1_Click(object sender, EventArgs e)
    {
       
       

        cargarGrilla();
   
          
    }
   

    public void cargarGrilla()
    {

        precio = txt_precioInfirme.Text;
        cupo = txt_cupoInforme.Text;
        destino = ddlDestinoInforme.SelectedIndex;

        gvViajesInforme.DataSource = GestorInformeViaje.filtrar(precio, cupo, destino);
        gvViajesInforme.DataBind();
    }

    private void cargarCombo()
    {
        ddlDestinoInforme.DataTextField = "descripcion";
        ddlDestinoInforme.DataValueField = "id";
        ddlDestinoInforme.DataSource = GestorDestino.ObtenerTodas();
        ddlDestinoInforme.DataBind();
        ddlDestinoInforme.Items.Insert(0, new ListItem("Elija un destino", "0"));
    }
}