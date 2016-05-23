<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hotel.aspx.cs" Inherits="Hotelwf" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-lg-12">
        <h1 class="page-header">Hoteles</h1>
        <ol class="breadcrumb">
            <li><a href="Inicio.aspx">Inicio</a></li>
            <li class="active">Hoteles</li>
        </ol>
    </div>

    <div class="col-lg-12">
        <asp:Label ID="lblAccion" CssClass="form-control label" runat="server" Text="Label"></asp:Label>
    </div>

    <div class="col-lg-12">
        <asp:Panel ID="Panel1" runat="server">
            <strong>Hotel:</strong>
            <div class="form-inline">
                <asp:TextBox ID="txtbxBuscar" class="form-control input-sm" runat="server">
                </asp:TextBox>
                <asp:CheckBox ID="chk_eliminados" class="checkbox-inline" Text="Ver eliminados" runat="server" OnCheckedChanged="chk_eliminados_CheckedChanged" />
                <asp:Button ID="btnBuscar" class="btn-sm btn-primary" role="button" type="submit" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>

            <table class="table table-bordered">
                <asp:GridView ID="GridView1" runat="server" class="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" AutoGenerateColumns="False">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"/>
                        <asp:BoundField DataField="descripcion" HeaderText="Nombre" SortExpression="descripcion"/>
                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"/>
                        <asp:BoundField DataField="capacidad" HeaderText="Capacidad" SortExpression="capacidad"/>
                        <asp:BoundField DataField="destino_descripcion" HeaderText="Ubicación" SortExpression="destino_descripcion"/>
                        <asp:BoundField DataField="cuit" HeaderText="CUIT" SortExpression="cuit" />
                    </Columns>
                    <SelectedRowStyle BackColor="Silver" />
                </asp:GridView>
            </table>

            <div class="btn-group-sm">
                <asp:Button ID="btnAgregar" runat="server" ControlStyle-CssClass="btn-default btn-sm" OnClick="btnAgregar_Click" Text="Agregar" />
                <asp:Button ID="btnConsultar" runat="server" ControlStyle-CssClass="btn-default btn-sm" OnClick="btnConsultar_Click" Text="Ver" />
                <asp:Button ID="btnEliminar" runat="server" ControlStyle-CssClass="btn-default btn-sm" OnClick="btnEliminar_Click" Text="Eliminar" />
                <asp:Button ID="btnEditar" runat="server" ControlStyle-CssClass="btn-default btn-sm" OnClick="btnEditar_Click" Text="Editar" />
            </div>

        </asp:Panel>
    </div>

    <div class="col-lg-12">
        <asp:Panel ID="pnlRegistro" runat="server">
            <table class="table-hover">
                <tr>
                    <td>Hotel Id:</td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" class="form-control" Style="margin-left: 0px" Enabled="False" Height="23px" Width="128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCuit" runat="server" Text="CUIT:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCuit" class="form-control" runat="server" Height="23px" Width="128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Nombre:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtdescripcion" class="form-control" runat="server" Height="23px" Width="128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCapacidad" class="form-control label" runat="server" Text="Capacidad"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCapacidad" class="form-control" runat="server" Height="23px" Width="128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Destino</td>
                    <td>
                        <asp:DropDownList ID="ddlDestino" class="form-control" runat="server" Height="23px" Width="128px" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPermiteMascota" class="form-control label" runat="server" Text="Admite Mascotas"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rb_list" runat="server" Height="16px" Width="191px">
                            <asp:ListItem Value="1">Sí</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" Width="71px" />
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Style="margin-left: 12px" Text="Cancelar/Volver" Width="103px" />
                        <asp:Button ID="btn_confirmarEliminar" runat="server" OnClick="btn_confirmarEliminar_Click" Style="margin-left: 22px" Text="confirmar Eliminar" Width="119px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div class="col-lg-12">
            <asp:Label ID="lbl_mensaje" class="form-control label alert-danger" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

