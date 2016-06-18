<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Paquete.aspx.cs" Inherits="Paquetesw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-lg-12">
        <h1 class="page-header">Paquete</h1>
        <ol class="breadcrumb">
            <li><a href="Inicio.aspx">Inicio</a></li>
            <li><a href="Viaje.aspx">Viajes</a></li>
            <li class="active">Paquete</li>
        </ol>
    </div>

    <div class="col-lg-12">
        <asp:Label ID="lblAccion" CssClass="form-control label" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-lg-12">
        <asp:Panel ID="Panel1" runat="server">
            <strong>Viajes:</strong>
            <table class="table table-bordered">
                <asp:GridView ID="GridView1" runat="server" class="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" AutoGenerateColumns="False">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"/>
                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"/>
                        <asp:BoundField DataField="destino_descripcion" HeaderText="Destino"/>
                        <asp:BoundField DataField="hotel_descripcion" HeaderText="Hotel" SortExpression="hotel_descripcion"/>
                        <asp:BoundField DataField="precioUnitario" HeaderText="Precio Unit." SortExpression="precioUnitario"/>
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" />
                        <asp:BoundField DataField="fechaSalida" HeaderText="Fecha" SortExpression="fechaSalida" />
                        <asp:BoundField DataField="subTotal" HeaderText="subTotal" SortExpression="subTotal" />
                        <asp:BoundField DataField="cupo" HeaderText="Cupo" SortExpression="cupo" />
                    </Columns>
                    <SelectedRowStyle BackColor="Silver" />
                </asp:GridView>
            </table>

            <div class="btn-group-sm">
                <asp:Button ID="btnAgregar" runat="server" ControlStyle-CssClass="btn-default btn-sm" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnEliminar" runat="server" ControlStyle-CssClass="btn-default btn-sm" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnSubTotales" runat="server" OnClick="btnSubTotales_Click" Text="Calcular SubTotal" />
                <asp:Button ID="btnComprar" runat="server" Text="Comprar" OnClick="btnComprar_Click" />
            </div>
        </asp:Panel>
    </div>

    <div class="col-lg-12">
        
        <div class="col-lg-12">
            <asp:Label ID="lbl_mensaje" class="form-control label alert-danger" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

