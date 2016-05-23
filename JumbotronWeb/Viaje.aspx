<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Viaje.aspx.cs" Inherits="Viaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Viajes
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Inicio.aspx">Inicio</a>
                    </li>
                    <li class="active">Viajes</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->

        <div class="row">
            <div class="col-md-3">
                <p class="lead">Paises</p>
                <div class="list-group">
                    <asp:Repeater ID="rpt_Paises" runat="server">
                        <ItemTemplate >
                            <a href='Viaje.aspx?id=<%# Eval("id") %>' class="list-group-item ui-selectable"><%# Eval("descripcion") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col-md-9">
                <asp:Repeater ID="rpt_Viajes" runat="server" OnItemCommand="rpt_Viajes_ItemCommand">
                    <ItemTemplate>
                        <div class="col-md-4 img-portfolio">
                            <a href="#">
                                <img class="img-responsive img-hover" src="img/<%# Eval("imagen") %>.jpg" alt="">
                            </a>
                            <h3>
                                <a href="#"><%# Eval("descripcion") %></a>
                            </h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                            <div class="caption">
                                <asp:Button ID="Button1" runat="server" Text="Comprar" CssClass="btn btn-primary" CommandArgument='<%#Eval("id") %>' CommandName="Comprar" />
                                <asp:Button ID="Button2" runat="server" Text="Ver" CommandName="Ver" CssClass="btn" CommandArgument='<%#Eval("id")%>' />
                                <h4 class="pull-right"><%# Eval("precio","{0:c}") %></h4>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>

</asp:Content>

