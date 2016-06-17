using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMViaje : System.Web.UI.Page
{
    private static  bool grabar;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (ddlDestino.AutoPostBack && pnlRegistro.Enabled == true)
        //{
        //    habilitar_panelRegistro(true);
        //}
        //else
           

        if (!Page.IsPostBack)
        {
            habilitar_panelRegistro(false);

            gvViajes.AllowPaging = true;
            gvViajes.AllowSorting = true;
            gvViajes.PageSize = 3;
            cargarGrilla(chk_eliminados.Checked);
            accion("");
            cargarComboDestino();
            cargarComboHotel();
            cargarComboTransporte();
            GestorABMViaje.actualizarDisponibles();
        }
    }

    public void cargarGrilla(bool elim)
    {
        gvViajes.DataSource = GestorABMViaje.buscarPorDescripcion(txtbxBuscar.Text, elim);
        gvViajes.DataBind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
         habilitar_botones("agregar_editar");
        accion("Agregando..");
        mensaje("");
        habilitar_campos(true);
        reiniciarPaneles();
        habilitar_panelRegistro(true);
        grabar = true;
        lblId.Visible = false;
        txtId.Visible = false;
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        if (gvViajes.SelectedRow == null)
        {
            mensaje("Debe seleccionar un hotel");
        }
        else
        {
            habilitar_panelRegistro(true);
            habilitar_botones("consultar");
            habilitar_campos(false);
            mensaje("");
            accion("Consultando..");

            try
            {
                recuperar(chk_eliminados.Checked);
            }
            catch (Exception ex)
            {
                mensaje(ex.Message);
            }
        }

    }

    public void mensaje(string msj)
    {
        lbl_mensaje.Text = msj;
    }

    public void habilitar_panelRegistro(bool accion)
    {
         pnlConsulta.Visible = !accion;
        pnlRegistro.Visible = accion;
    }

    public void habilitar_botones(string accion)
    {
        switch (accion)
        {
            case "eliminar_click":

                btnGrabar.Visible = false;
                btn_confirmarEliminar.Visible = true;
                btnCancelar.Visible = true;
                break;

            case "agregar_editar":
                btn_confirmarEliminar.Visible = false;
                btnGrabar.Visible = true;
                btnCancelar.Visible = true;


                break;

            case "consultar":
                btn_confirmarEliminar.Visible = false;
                btnGrabar.Visible = false;
                btnCancelar.Visible = true;
                pnlConsulta.Visible = false;
                pnlRegistro.Visible = true;
                break;
        }
    }
    private void habilitar_campos(Boolean estado)
    {
        
        txtdescripcion.Enabled = estado;
        ddlDestino.Enabled = estado;
        txtCupo.Enabled = estado;
        txtFechaLlegada.Enabled = estado;
        txtFechaSalida.Enabled = estado;
        txtPrecio.Enabled = estado;
        ddlHotel.Enabled = estado;
        ddlTransporte.Enabled = estado;
        rb_Disponibilidad.Enabled = estado;
        txtimagen.Enabled = estado;
    }
    private void recuperar(bool eliminados)
    {
        int id = (int)gvViajes.SelectedValue;
        Viaje h = GestorViaje.buscarPorId(id, eliminados);
        txtId.Text = h.id.ToString();
        txtdescripcion.Text = h.descripcion;
        ddlDestino.SelectedValue = h.destino.ToString();
        ddlHotel.SelectedValue = h.hotel.ToString();
        ddlTransporte.SelectedValue = h.transporte.ToString();
        txtPrecio.Text = h.precio.ToString();
        txtCupo.Text = h.cupo.ToString();
        if (rb_Disponibilidad.SelectedValue == "1")
            rb_Disponibilidad.Items[1].Selected = true;
        else
            rb_Disponibilidad.Items[0].Selected = true;

        txtFechaLlegada.Text = Convert.ToString(h.fechaLlegada);
        txtFechaSalida.Text = Convert.ToString(h.fechaSalida);
        txtimagen.Text = h.imagen;
    }

    public void accion(string mensaje)
    {
        lblAccion.Text = mensaje;
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (gvViajes.SelectedRow == null)
            mensaje("Debe seleccionar un hotel");

        else
        {
            habilitar_panelRegistro(true);
            habilitar_botones("eliminar_click");
            mensaje("");
            accion("Eliminando..");
            habilitar_campos(false);

            recuperar(chk_eliminados.Checked);
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (gvViajes.SelectedRow == null)
            mensaje("Debe seleccionar un hotel");
        else
        {
            habilitar_panelRegistro(true);
            habilitar_botones("agregar_editar");
            if (chk_eliminados.Checked)
                accion("Recuperando..");
            else
                accion("Editando..");
            habilitar_campos(true);
            grabar = false;
            recuperar(chk_eliminados.Checked);
        }
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        
         habilitar_panelRegistro(false);
        accion("Grabando..");
        Viaje h = new Viaje();

        if (validar())
        {
            if (txtCupo.Text != "")
                h.cupo = Convert.ToInt32(txtCupo.Text);
            else
                h.cupo = -1;

            h.descripcion = txtdescripcion.Text;

            if (txtPrecio.Text != "")
                h.precio = Convert.ToInt32(txtPrecio.Text);
            else
                h.precio = -1;

            h.destino = Convert.ToInt32(ddlDestino.SelectedValue);

            h.transporte = Convert.ToInt32(ddlTransporte.SelectedValue);

            h.hotel = Convert.ToInt32(ddlHotel.SelectedValue);

            if (rb_Disponibilidad.SelectedValue == "1")
                h.disponible = true;
            else
                h.disponible = false;

            if (txtFechaLlegada.Text != "")
                h.fechaLlegada = Convert.ToDateTime(txtFechaLlegada.Text);
            else
                h.fechaLlegada = Convert.ToDateTime("01/01/2000");

            if (txtFechaSalida.Text != "")
                h.fechaSalida = Convert.ToDateTime(txtFechaSalida.Text);
            else
                h.fechaSalida = Convert.ToDateTime("01/01/2000");

            if (txtimagen.Text != "")
            {
                h.imagen = txtimagen.Text;
            }

            if (!grabar)
            {
                h.id = Convert.ToInt32(txtId.Text);  
            }


            GestorABMViaje.Grabar(h, grabar); //si está habilitado el textID es porq graba, sino actualiza
            cargarGrilla(chk_eliminados.Checked);
        }

    
    }

    Regex Validar_numeros = new Regex(@"^[0-9]*$");

    private Boolean validar()
    {
        int idExistente = 0;
        string destinoExistente = "";

        if (txtCupo.Text == "" || !Validar_numeros.IsMatch(txtCupo.Text))
        {
            rechazar_grabado(txtCupo);
            return false;
        }


        if (txtdescripcion.Text == "")
        {
            rechazar_grabado(txtdescripcion);
            return false;
        }
        if (txtPrecio.Text == "" || !Validar_numeros.IsMatch(txtPrecio.Text))
        {
            rechazar_grabado(txtPrecio);
            return false;
        }

        if (rb_Disponibilidad.SelectedItem == null)
        {
            rechazar_grabado(rb_Disponibilidad);
            return false;
        }

        if (ddlDestino.SelectedValue == "0" || ddlDestino.SelectedValue == "" || ddlDestino.SelectedValue == "-1")
        {
            rechazar_grabado(ddlDestino);
            return false;
        }

        if (ddlHotel.SelectedValue == "0" || ddlHotel.SelectedValue == "" || ddlHotel.SelectedValue == "-1" )
        {
            rechazar_grabado(ddlHotel);
            return false;
        }

        if (ddlTransporte.SelectedValue == "0" || ddlTransporte.SelectedValue == "" || ddlTransporte.SelectedValue == "-1")
        {
            rechazar_grabado(ddlTransporte);
            return false;
        }

        if (txtFechaLlegada.Text == "" || Convert.ToDateTime(txtFechaLlegada.Text) < DateTime.Today)
        {
            rechazar_grabado(txtFechaLlegada);
            return false;
        }

        if (txtFechaSalida.Text == "" || Convert.ToDateTime(txtFechaLlegada.Text) < DateTime.Today)
        {
            rechazar_grabado(txtFechaSalida);
            return false;
        }
        if (Convert.ToDateTime(txtFechaLlegada.Text) < Convert.ToDateTime(txtFechaSalida.Text))
        {
            rechazar_fecha(txtFechaLlegada);
            return false;
        }

        if (txtimagen.Text == "" || GestorABMViaje.existeImagen(txtimagen.Text, out idExistente, out destinoExistente) )
        {
            if (idExistente != 0)
            {
                rechazarImagen_repetida(txtimagen.Text, idExistente, destinoExistente);
                return false;
            }
            rechazar_grabado(txtimagen);
            return false;
        }
        return true;
    }

    private void rechazar_fecha(TextBox txtFechaLlegada)
    {
        habilitar_panelRegistro(true);
        mensaje("Debe ingresar una fecha de llegada que no sea menor a la de llegada");
        txtFechaLlegada.Focus();
    }
    private void rechazar_grabado(Control c)
    {
        habilitar_panelRegistro(true);
        mensaje("Debe ingresar un " + c.ID + " válido");
        c.Focus();
    }
    private void rechazarImagen_repetida(string imagen, int id, string destino)
    {
        habilitar_panelRegistro(true);
        mensaje("El viaje con destino a " + destino + " id= " + id + " ya posee la imagen " + imagen);
        txtimagen.Focus();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        habilitar_panelRegistro(false);
    }
    protected void btn_confirmarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            int id = (int)gvViajes.SelectedValue;
            GestorABMViaje.Eliminar(id);
        }
        catch (Exception ex)
        {
            mensaje(ex.Message);
        }

        habilitar_panelRegistro(false);
        cargarGrilla(chk_eliminados.Checked);
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        cargarGrilla(chk_eliminados.Checked);
    }
    protected void chk_eliminados_CheckedChanged(object sender, EventArgs e)
    {
        btnEliminar.Visible = !chk_eliminados.Checked;
        if (chk_eliminados.Checked)
            btnEditar.Text = "Recuperar";
        else
            btnEditar.Text = "Editar";
        cargarGrilla(chk_eliminados.Checked);
    }

   
    public void cargarComboDestino()
    {
        ddlDestino.DataTextField = "descripcion";
        ddlDestino.DataValueField = "id";
        ddlDestino.DataSource = GestorDestino.ObtenerTodas();
        ddlDestino.DataBind();
        ddlDestino.Items.Insert(0, new ListItem("Elija una provincia", "0"));

    }
    public void cargarComboTransporte()
    {
        ddlTransporte.DataTextField = "descripcion";
        ddlTransporte.DataValueField = "id";
        ddlTransporte.DataSource = GestorTransporte.ObtenerTodas();
        ddlTransporte.DataBind();
        ddlTransporte.Items.Insert(0, new ListItem("Elija un transporte", "0"));

    }
    public void cargarComboHotel()
    {
        //bool todas = true;
        //if (!(Convert.ToInt32(ddlDestino.SelectedValue) == 0))
        //{
        //    todas=false;
        //}

        ddlHotel.DataTextField = "descripcion";
        ddlHotel.DataValueField = "id";
        ddlHotel.DataSource = GestorHotel.filtrarHoteles(ddlDestino.SelectedValue);
        ddlHotel.DataBind();
        ddlHotel.Items.Insert(0, new ListItem("Elija un Hotel", "0"));

    }
    public void reiniciarPaneles()
    {
        txtId.Text = "";
        txtCupo.Text = "";
        ddlDestino.ClearSelection();
        ddlHotel.ClearSelection();
        ddlTransporte.ClearSelection();
        rb_Disponibilidad.ClearSelection();
        txtPrecio.Text = "";
        txtdescripcion.Text = "";
        txtFechaLlegada.Text = "";
        txtFechaSalida.Text = "";
        txtimagen.Text = "";
    }


    protected void gvViajes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
         gvViajes.PageIndex = e.NewPageIndex;
        cargarGrilla(chk_eliminados.Checked);

    }

    //protected void ddlDestino_TextChanged(object sender, EventArgs e)
    //{
    //    ddlDestino.AutoPostBack = true;
    //    cargarComboHotel();
    //}
    protected void ddlDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDestino.AutoPostBack = true;
        cargarComboHotel();

    }
}