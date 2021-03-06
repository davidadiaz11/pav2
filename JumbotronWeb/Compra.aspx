﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Compra.aspx.cs" Inherits="Compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-lg-12">
        <h1 class="page-header">Compra</h1>
        <ol class="breadcrumb">
            <li><a href="Inicio.aspx">Inicio</a></li>
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
                <asp:GridView ID="grilla_compra" runat="server" class="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="grilla_compra_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"/>
                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"/>
                        <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio"/>
                        <asp:BoundField DataField="fechaSalida" HeaderText="Fecha Salida" SortExpression="fechaSalida" />
                    </Columns>
                    <SelectedRowStyle BackColor="Silver" />
                </asp:GridView>
            </table>

            <table class="nav-justified">
                <tr>
                    <td>
                        <table class="nav-justified">
                            <tr>
                                <td>Cantidad de Paquetes:
                                    <asp:Label ID="lblCantPaq" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Importe TOTAL:
                                    <asp:Label ID="lblImporteTOTAL" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div class="btn-group-sm">
                <asp:Button ID="btnAgregar" runat="server" ControlStyle-CssClass="btn-default btn-sm" OnClick="btnAgregar_Click" Text="Agregar" />
                <asp:Button ID="btnEliminar" runat="server" ControlStyle-CssClass="btn-default btn-sm" OnClick="btnEliminar_Click" Text="Eliminar" />
                <asp:Button ID="btnComprar" runat="server" OnClick="btnComprar_Click" Text="Comprar" />
                <div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <div class="col-lg-12">
        
        <div class="col-lg-12">
            <asp:Label ID="lbl_mensaje" class="form-control label alert-danger" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

