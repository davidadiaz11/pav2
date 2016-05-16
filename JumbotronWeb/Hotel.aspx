<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hotel.aspx.cs" Inherits="Hotelwf" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
            width: 117px;
        }
        .auto-style5 {
            height: 33px;
            width: 117px;
        }
        .auto-style6 {
            height: 33px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            width: 117px;
            height: 26px;
        }


        .auto-style10 {
            width: 399px;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="height: 34px">
    <h2> Hotel
        <asp:Label ID="lblAccion" runat="server" Text="Label"></asp:Label>
    </h2>
</p>
    <asp:Panel ID="Panel1" runat="server">
        <strong>Nombre a buscar:&nbsp;</strong>
        
        <asp:TextBox ID="txtbxBuscar"  class="form-control" runat="server" Width="150px"></asp:TextBox>
           <asp:Button ID="btnBuscar"  class="btn btn-primary" role="button" type="submit" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
          <br />

        
    <table class="table table-bordered">
        <asp:GridView ID="GridView1" runat="server"   CellPadding="4"  DataKeyNames="codigo" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="codigo" HeaderText="Codigo" SortExpression="codigo" />
                <asp:BoundField DataField="capacidad" HeaderText="Capacidad" />
                <asp:BoundField DataField="destino_descripcion" HeaderText="Ubicacion" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
   </table>
        <br />
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" Width="65px" style="height: 26px" />
        <asp:Button ID="btnConsultar" runat="server" Height="26px" OnClick="btnConsultar_Click" style="margin-left: 5px" Text="Consultar" Width="65px" />
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" style="margin-left: 6px" Text="Eliminar" Width="65px" />
        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" style="margin-left: 6px" Text="Editar" Width="65px" />
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlRegistro" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Hotel Id:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtId" runat="server" class="form-control input-lg" style="margin-left: 0px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblCuit" runat="server" Text="CUIT:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCuit" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Nombre:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtCapacidad" runat="server" style="margin-top: 9px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Destino</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlDestino" runat="server" Enabled="False" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblPermiteMascota" runat="server" Text="Admite Mascotas"></asp:Label>
                </td>
                <td class="auto-style7">

                    <%--borre el codigo:OnCheckedChanged="rbrtnNo_CheckedChanged" , en ambos radiobutton para que mecompilara 
                        preguntar al profe como hacer para que funcionen al seleccionarse y deseleccionarlos --%>
                    <asp:RadioButton ID="rbtnSi" runat="server" Text="SI" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbrtnNo" runat="server"  Text="No" />
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">
                    <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" Width="71px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" style="margin-left: 12px" Text="Cancelar/Volver" Width="103px" />
                    &nbsp;<asp:Button ID="btn_confirmarEliminar" runat="server" OnClick="btn_confirmarEliminar_Click" style="margin-left: 22px" Text="confirmar Eliminar" Width="119px" />
                </td>
            </tr>
        </table>
        
    </asp:Panel>
    <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
</asp:Content>

