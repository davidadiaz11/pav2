﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;




//AL EDITAR, SE BLOQUEA EL TXT, Y DE ESO DEPENDERÁ QUE DESPUÉS GRABAR() HAGA UN INSERT O UN UPDATE
//SI TXT_ID ESTA HABILITADO ES PORQUE SE TRATA DE UN INSERT
//SI TXT_ID ESTA DESHABILITADO ES PORQUE SE TRATA DE UNA MODIFICACIÓN, OSEA UPDATE

//La cadena de conexión se escribe una sola vez, en la clase GestorHotel
//se escribieron métodos para validar el relleno de los campos.. validar()
//se escribió un método para habilitar/deshabilitar los campos.. habilitar(true para q habilite, false para q deshabilite)
//se escribió un método para rechazar la grabación de campos defectuosos, haciendo foco en el control q lo produjo


//hay q controlar el grabado de nuevos hoteles con ID existente
//Hay que incluir paginación.. no se q onda pero se rompe tooo

//TODO agregué métodos para habilitar paneles, botones y mensajes/acciones(labels)
//TODO ya se está validando el ingreso de sólo números en los campos ID, CUIT y capacidad.
//si no ingresa nada, el ID será autoincrementado y el CUIT y capacidad serán -1



public partial class Hotelwf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        habilitar_panelRegistro(false);

        if (!Page.IsPostBack)
        {//TODO no funciona esto
            //if (!Page.User.IsInRole("Administradores"))
            //{
            //    btnEliminar.Visible = false;
            //    btnEditar.Visible = false;
            //    btnAgregar.Visible = false;
            //}

            ViewState["GvDatosOrden"] = "descripcion";
            GridView1.AllowPaging = true;
            GridView1.AllowSorting = true;
            //definir columnas que se van a ve dataBound --> .textheader(titulo), datafield(propiedades del datasource), sortexpression
            GridView1.PageSize = 7;
            cargarGrilla(chk_eliminados.Checked);
            accion("");
            cargarCombo();
        }
    }


    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow == null)
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

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

        if (GridView1.SelectedRow == null)
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





    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        habilitar_botones("agregar_editar");
        accion("Agregando..");
        habilitar_campos(true);
        reiniciarPaneles();
        habilitar_panelRegistro(true);
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {

        if (GridView1.SelectedRow == null)
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
            txtId.Enabled = false;
            recuperar(chk_eliminados.Checked);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        habilitar_panelRegistro(false);
        cargarGrilla(chk_eliminados.Checked);
    }

    protected void btn_confirmarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            int id = (int)GridView1.SelectedValue;
            GestorHotel.Eliminar(id);
        }
        catch (Exception ex)
        {
            mensaje(ex.Message);
        }

        habilitar_panelRegistro(false);
        cargarGrilla(chk_eliminados.Checked);

    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        habilitar_panelRegistro(false);
        accion("Grabando..");
        Hotel h = new Hotel();

        if (validar())
        {
            if (txtId.Text != "")
                h.id = Convert.ToInt32(txtId.Text);
            else
                h.id = -1;

            if (txtCuit.Text != "")
                h.cuit = Convert.ToInt32(txtCuit.Text);
            else
                h.cuit = -1;

            h.descripcion = txtdescripcion.Text;
            if (txtCapacidad.Text != "")
                h.capacidad = Convert.ToInt32(txtCapacidad.Text);
            else
                h.capacidad = -1;

            h.destino = Convert.ToInt32(ddlDestino.SelectedValue);

            if (rb_list.SelectedValue == "1")
                h.aceptaMascota = true;
            else
                h.aceptaMascota = false;


            GestorHotel.Grabar(h, txtId.Enabled); //si está habilitado el textID es porq graba, sino actualiza
            cargarGrilla(chk_eliminados.Checked);
        }

    }
    Regex Validar_numeros = new Regex(@"^[0-9]*$");
    private Boolean validar()
    {
        if (txtId.Text != "") //si no es vacío
        {
            if (!Validar_numeros.IsMatch(txtId.Text)) //y no son números
            {
                rechazar_grabado(txtId);
                return false;
            }

            if (GestorHotel.existe(Convert.ToInt32(txtId.Text)) && txtId.Enabled) //y no existe
            {
                rechazar_repetido(txtId.Text);
                return false;
            }
        }
        if (txtCuit.Text != "" && !Validar_numeros.IsMatch(txtCuit.Text))
        {
            rechazar_grabado(txtCuit);
            return false;
        }

        if (txtCuit.Text != ""  && GestorHotel.existeCuit(Convert.ToInt32(txtCuit.Text)) && txtId.Enabled)
        {
            rechazarCuit_repetido(txtCuit.Text);
            return false;
        }

        if (txtdescripcion.Text == "")
        {
            rechazar_grabado(txtdescripcion);
            return false;
        }
        if (txtCapacidad.Text != "" && !Validar_numeros.IsMatch(txtCapacidad.Text))
        {
            rechazar_grabado(txtCapacidad);
            return false;
        }

        if (rb_list.SelectedItem == null)
        {
            rechazar_grabado(rb_list);
            return false;
        }

        if (ddlDestino.SelectedValue == "0" || ddlDestino.SelectedValue == "" || ddlDestino.SelectedValue == "-1")
        {
            rechazar_grabado(ddlDestino);
            return false;
        }

        return true;
    }
    private void rechazar_grabado(Control c)
    {
        habilitar_panelRegistro(true);
        mensaje("Debe ingresar un " + c.ID + " válido");
        c.Focus();
    }

    private void rechazar_repetido(string id)
    {
        habilitar_panelRegistro(true);
        mensaje("Ya existe un hotel con ID " + id);
        txtId.Focus();
    }

    private void rechazarCuit_repetido(string cuit)
    {
        habilitar_panelRegistro(true);
        mensaje("Ya existe un hotel con CUIT: " + cuit);
        txtCuit.Focus();
    }


    private void habilitar_campos(Boolean estado)
    {
        txtId.Enabled = estado;
        txtdescripcion.Enabled = estado;
        ddlDestino.Enabled = estado;
        txtCapacidad.Enabled = estado;
        txtCuit.Enabled = estado;
        rb_list.Enabled = estado;
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        cargarGrilla(chk_eliminados.Checked);
    }

    private void recuperar(bool eliminados)
    {
        int id = (int)GridView1.SelectedValue;
        Hotel h = GestorHotel.buscarPorId(id, eliminados);
        txtId.Text = h.id.ToString();
        txtdescripcion.Text = h.descripcion;
        ddlDestino.SelectedValue = h.destino.ToString();
        txtCuit.Text = h.cuit.ToString();
        txtCapacidad.Text = h.capacidad.ToString();
        if (rb_list.SelectedValue == "1")
            rb_list.Items[1].Selected = true;
        else
            rb_list.Items[0].Selected = true;
    }


    public void mensaje(string msj)
    {
        lbl_mensaje.Text = msj;
    }
    public void accion(string mensaje)
    {
        lblAccion.Text = mensaje;
    }
    public void reiniciarPaneles()
    {
        txtId.Text = "";
        txtCuit.Text = "";
        ddlDestino.ClearSelection();
        rb_list.ClearSelection();
        txtCapacidad.Text = "";
        txtdescripcion.Text = "";
    }

    private void cargarCombo()
    {
        ddlDestino.DataTextField = "descripcion";
        ddlDestino.DataValueField = "id";
        ddlDestino.DataSource = GestorDestino.ObtenerTodas();
        ddlDestino.DataBind();
        ddlDestino.Items.Insert(0, new ListItem("Elija una provincia", "0"));
    }
    public void cargarGrilla(bool eliminados)
    {
        string orden = ViewState["GvDatosOrden"].ToString();
        GridView1.DataSource = GestorHotel.BuscarPordescripcion(txtbxBuscar.Text, orden, eliminados);
        GridView1.DataBind();
        mensaje(GridView1.Rows.Count.ToString()+" hoteles encontrados");
        accion("");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["GvDatosOrden"] = e.SortExpression;
        cargarGrilla(chk_eliminados.Checked);
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    public void habilitar_panelRegistro(bool accion)
    {
        Panel1.Visible = !accion;
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
                    Panel1.Visible = false;
                    pnlRegistro.Visible = true;
                    break;
            }
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
}