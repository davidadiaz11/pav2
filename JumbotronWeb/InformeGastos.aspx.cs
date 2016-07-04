using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformeGastos : System.Web.UI.Page
{
    string precio;
    string fecha ;
    string usuario;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCombo();
            cargarGrilla();
        }

    }

    public void cargarGrilla()
    {

        precio = txt_precio.Text;
        fecha = txt_fecha.Text;
        
        string usuario = GestorUsuarios.buscarIdUusario(Convert.ToInt32(ddl_usuario.SelectedIndex));

        grilla_gastos.DataSource = GestorInformeGastos.filtrar(precio, fecha, usuario);
        grilla_gastos.DataBind();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        cargarGrilla();
    }


    private void cargarCombo()
    {
        ddl_usuario.DataTextField = "id";
        ddl_usuario.DataValueField = "num";
        ddl_usuario.DataSource = GestorUsuarios.obtenerUsuarios();
        ddl_usuario.DataBind();
        ddl_usuario.Items.Insert(0, new ListItem("Elija un Usuario", "0"));
    }
}