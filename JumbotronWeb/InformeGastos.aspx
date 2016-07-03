<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeGastos.aspx.cs" Inherits="InformeGastos" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <head> <h3> Informe de Gastos por Usuario</h3>
         <h4> Filtros:</h4>
         <div>
             <table class="nav-justified">
                 <tr>
                     <td>Precio Maximo:</td>
                     <td>
                         <asp:TextBox ID="txt_precio" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style1">Fecha: </td>
                     <td class="auto-style1">
                         <asp:TextBox ID="txt_fecha" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Paquete:</td>
                     <td>
                         <asp:DropDownList ID="ddl_paquete" runat="server" CssClass="form-control"  Width="148px">
                         </asp:DropDownList>

                     </td>
                 </tr>
             </table>
         </div>
     </head>

    <body>
         <asp:GridView ID="grilla_gastos" runat="server" CssClass="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descrip" SortExpression="descripcion" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                    <asp:BoundField DataField="fechaSalida" HeaderText="Fecha Salida" SortExpression="fechaSalida" />
                    <asp:BoundField DataField="fechaLlegada" HeaderText="Fecha Lleg" SortExpression="fechaLlegada" />
                    <asp:BoundField DataField="destinoNombre" HeaderText="Destino" SortExpression="destinoNombre" />
                    <asp:BoundField DataField="cupo" HeaderText="Cupo" SortExpression="cupo" />
                </Columns>
                <SelectedRowStyle BackColor="Silver" />
            </asp:GridView>
    </body>

</asp:Content>

