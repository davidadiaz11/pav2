<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <asp:Login ID="ctrl_login" runat="server" OnAuthenticate="ctrl_login_Authenticate"></asp:Login>
    usuarios: pasajero, admin
    password: asd
    sino... configurar linea 23 deny users="?" del webconfig 
    <br />
    <br />
</asp:Content>


