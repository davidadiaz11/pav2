using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hotelwf : System.Web.UI.Page
{
    bool ban;

    protected void Page_Load(object sender, EventArgs e)
    {

        Panel1.Visible = true;
        pnlRegistro.Visible = false;

        lbl_mensaje.Text = "";

       
        lblAccion.Text = "";



        if (!Page.IsPostBack)
        {
            ViewState["GvDatosOrden"] = "nombre";
            GridView1.AllowPaging = true;
            GridView1.AllowSorting = true;
            //definir columnas que se van a ve dataBound --> .textheader(titulo), datafield(propiedades del datasource), sortexpression
            GridView1.PageSize = 7;

            cargarGrilla();

            lblAccion.Text = "";

            cargarCombo();
            
        }

    }


    private void cargarCombo()
    {
        ddlDestino.DataTextField = "descripcion";
        ddlDestino.DataValueField = "codigo";
        ddlDestino.DataSource = GestorDestino.ObtenerTodas();
        ddlDestino.DataBind();
        ddlDestino.Items.Insert(0, new ListItem("Elija una provincia", "0"));
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        pnlRegistro.Visible = true;
        lblAccion.Text = "Agregando..";
        ddlDestino.Enabled = true;
        txtId.Enabled = false;

        btnCancelar.Enabled = true;
        btnGrabar.Enabled = true;
        btnGrabar.Visible = true;
        btn_confirmarEliminar.Visible = false;
        reiniciarCamposIngreso();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {

        if (GridView1.SelectedRow == null)
        {
            lbl_mensaje.Visible = true;
            lbl_mensaje.Text = "Debe seleccionar un hotel";
        }
        else
        {
            lbl_mensaje.Text = "";
            Panel1.Visible = false;
            pnlRegistro.Visible = true;
            lblAccion.Text = "Consultando..";
            btnGrabar.Visible = false;
            btn_confirmarEliminar.Visible = false;
            

            int codigo = (int)GridView1.SelectedValue;
            try
            {
                Hotel h = GestorHotel.buscarPorId(codigo);
                txtId.Text = h.codigo.ToString();
                txtNombre.Text = h.nombre.ToString();
                txtCapacidad.Text = h.capacidad.ToString();
                txtCuit.Text = h.cuit.ToString();
                ddlDestino.SelectedIndex = (int)h.destino;
            }
            catch (Exception ex)
            {

                lbl_mensaje.Text = ex.Message;
            }
            
        }
    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {

        if (GridView1.SelectedRow == null)
        {
            lbl_mensaje.Visible = true;
            lbl_mensaje.Text = "Debe seleccionar un hotel";
        }
        else
        {

            lbl_mensaje.Text = "";
            Panel1.Visible = false;
            pnlRegistro.Visible = true;
            lblAccion.Text = "Eliminando..";

            int codigo = (int)GridView1.SelectedValue;

            Hotel h = GestorHotel.buscarPorId(codigo);
            txtId.Text = h.codigo.ToString();
            txtNombre.Text = h.nombre.ToString();
            txtCapacidad.Text = h.capacidad.ToString();
            txtCuit.Text = h.cuit.ToString();
            ddlDestino.SelectedValue = h.destino.ToString();

            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtCapacidad.Enabled = false;
            txtCuit.Enabled = false;
            ddlDestino.Enabled = false;

            btnGrabar.Visible = false;
            btn_confirmarEliminar.Visible = true;
            btnCancelar.Visible = true;

        }

    }


    protected void btnEditar_Click(object sender, EventArgs e)
    {
        

        if (GridView1.SelectedRow == null)
        {
            lbl_mensaje.Visible = true;
            lbl_mensaje.Text = "Debe seleccionar un hotel";
        }
        else
        {
            Panel1.Visible = false;
            pnlRegistro.Visible = true;
            lblAccion.Text = "Editando..";
            ddlDestino.Enabled = true;
            btnGrabar.Visible = true;
            btn_confirmarEliminar.Visible = false;
            btnCancelar.Visible = true;
           

            int codigo = (int)GridView1.SelectedValue;
            try
            {
                Hotel h = GestorHotel.buscarPorId(codigo);
                txtId.Text = h.codigo.ToString();
                txtNombre.Text = h.nombre.ToString();
                txtCapacidad.Text = h.capacidad.ToString();
                txtCuit.Text = h.cuit.ToString();
                ddlDestino.SelectedValue = h.destino.ToString();
            }
            catch (Exception ex)
            {

                lbl_mensaje.Text = ex.Message;
            }
       
        }


    }

    //ver grabar y grabar_click
    protected void btnGrabar_Click(object sender, EventArgs e)
    {

        Panel1.Visible = true;
        pnlRegistro.Visible = false;
        //  lblAccion.Text = "Grabando..";
        Hotel h2 = new Hotel();
        tomarDatos(h2);
        GestorHotel.Grabar(h2);

    }

    private void tomarDatos(Hotel h2)
    {
        h2.nombre = txtNombre.Text;
        h2.cuit = int.Parse(txtCuit.Text);

        if (txtId.Text != "")
            h2.codigo = int.Parse(txtId.Text);

        if (txtCapacidad.Text != "")
        {
            h2.capacidad = int.Parse(txtCapacidad.Text);
        }

        if (ddlDestino.SelectedValue != "0")
        {
            h2.destino = int.Parse(ddlDestino.SelectedValue);
        }
        else
        {
            h2.destino = null;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

        Panel1.Visible = true;
        pnlRegistro.Visible = false;

        cargarGrilla();

    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        cargarGrilla();

    }



    /*  protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
      {
          Panel1.Visible=false;
          pnlRegistro.Visible=true;
        
          int codigo = (int)GridView1.SelectedValue;

          Hotel h = GestorHotel.buscarPorId(codigo);
          txtId.Text=h.codigo.ToString();
          txtNombre.Text=h.nombre.ToString();
      }*/



    protected void btn_confirmarEliminar_Click(object sender, EventArgs e)
    {

        try
        {
            int codigo = (int)GridView1.SelectedValue;
            GestorHotel.Eliminar(codigo);
        }
        catch (Exception ex)
        {

            lbl_mensaje.Text = ex.Message;
        }


        pnlRegistro.Visible = false;
        Panel1.Visible = true;

        cargarGrilla();

    }


    public void reiniciarPaneles()
    {

        pnlRegistro.Visible = false;
        Panel1.Visible = true;
        lblAccion.Text = "";

    }


    public void cargarGrilla()
    {
        string orden = ViewState["GvDatosOrden"].ToString();
        GridView1.DataSource = GestorHotel.BuscarPorNombre(txtbxBuscar.Text, orden);
        GridView1.DataBind();
        lblAccion.Text = "";

    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;

    }


    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

        ViewState["GvDatosOrden"] = e.SortExpression;
        cargarGrilla();

    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void reiniciarCamposIngreso()
    {

        txtId.Text = "";
        txtCuit.Text = "";
        txtCapacidad.Text = "";
        txtNombre.Text = "";
        ddlDestino.SelectedIndex = 0;

    }

}