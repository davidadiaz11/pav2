﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeViaje.aspx.cs" Inherits="InformeViaje" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <head> <h3> Informe Viaje</h3>
         <h4> Filtros:</h4>
         <div>
             <table class="nav-justified">
                 <tr>
                     <td>Precio Máximo:</td>
                     <td>
                         <asp:TextBox ID="txt_precioInfirme" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style1">Cupo Máximo: </td>
                     <td class="auto-style1">
                         <asp:TextBox ID="txt_cupoInforme" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Destino:</td>
                     <td>
                        

                         <asp:DropDownList ID="ddlDestinoInforme" runat="server" CssClass="form-control" AutoPostBack="True" Width="148px">
                         </asp:DropDownList>

                     </td>
                     <tr>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                        </td>
                     </tr>
                 </tr>
             </table>
         </div>
     </head>

    <body>
         <asp:GridView ID="gvViajesInforme" runat="server" CssClass="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False" Width="1084px" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descrip" SortExpression="descripcion" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                    <asp:BoundField DataField="fechaSalida" HeaderText="Fecha Salida" SortExpression="fechaSalida" />
                    <asp:BoundField DataField="fechaLlegada" HeaderText="Fecha Lleg" SortExpression="fechaLlegada" />
                    <asp:BoundField DataField="destino" HeaderText="Destino" SortExpression="destinoNombre" />
                    <asp:BoundField DataField="cupo" HeaderText="Cupo" SortExpression="cupo" />
                </Columns>
                <SelectedRowStyle BackColor="Silver" />
            </asp:GridView>
         <div>
             <asp:Button ID="btn_FiltrarBusqueda" runat="server" OnClick="Button1_Click" Text="Buscar" />
         </div>
    </body>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</asp:Content>


