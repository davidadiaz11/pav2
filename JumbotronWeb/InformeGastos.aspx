<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeGastos.aspx.cs" Inherits="InformeGastos" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <head> <h3> Informe de Compras</h3>
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
                         <asp:TextBox ID="txt_fecha" runat="server" Height="26px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Usuario:</td>
                     <td>
                         <asp:DropDownList ID="ddl_usuario" runat="server" CssClass="form-control"  Width="148px">
                         </asp:DropDownList>

                     </td>
                 </tr>
             </table>
         </div>
     </head>

    <body>
         <div>
             <asp:Button ID="btn_buscar" runat="server" OnClick="btn_buscar_Click" Text="Buscar" />
         </div>
         <asp:GridView ID="grilla_gastos" runat="server" CssClass="table table-responsive table-bordered table-hover" CellPadding="4" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                    <asp:BoundField DataField="montoTotal" HeaderText="Monto total" SortExpression="precio" />
                    <asp:BoundField DataField="cantPaquetes" HeaderText="Cant Paquetes" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha Compra" />
                </Columns>
                <SelectedRowStyle BackColor="Silver" />
            </asp:GridView>
    </body>

</asp:Content>

