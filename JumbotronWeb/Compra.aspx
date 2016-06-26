<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Compra.aspx.cs" Inherits="Compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-lg-12">
        <h1 class="page-header">Compra</h1>
        <ol class="breadcrumb">
            <li><a href="Inicio.aspx">Inicio</a></li>
            <li><a href="Paquete.aspx">Paquete</a></li>
            <li class="active">Compra</li>
        </ol>
    </div>

    <div class="col-lg-12">
        <asp:Label ID="lblAccion" CssClass="form-control label" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-lg-12">
        <asp:Panel ID="Panel1" runat="server">
            <strong>Paquetes:</strong>
            <table class="table table-bordered">
                <asp:GridView ID="grilla_compra" runat="server" class="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"/>
                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"/>
                        <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio"/>
                        <asp:BoundField DataField="fechaSalida" HeaderText="Fecha Salida" SortExpression="fechaSalida" />
                    </Columns>
                    <SelectedRowStyle BackColor="Silver" />
                </asp:GridView>
            </table>

            <div class="btn-group-sm">
                <asp:Button ID="btnAgregar" runat="server" ControlStyle-CssClass="btn-default btn-sm" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnEliminar" runat="server" ControlStyle-CssClass="btn-default btn-sm" Text="Eliminar" OnClick="btnEliminar_Click" />
            </div>
        </asp:Panel>
    </div>

    <div class="col-lg-12">
        
        <div class="col-lg-12">
            <asp:Label ID="lbl_mensaje" class="form-control label alert-danger" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

