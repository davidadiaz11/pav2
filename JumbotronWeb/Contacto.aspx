<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contacto.aspx.cs" Inherits="AcercaDe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Contacto
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Inicio.aspx">Inicio</a>
                    </li>
                    <li class="active">Contacto</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        <!-- Content Row -->
        <div class="row">
            <div class="col-md-6">
                <h3>Envíanos un mensaje</h3>
                <form name="sentMessage" id="formcontacto" novalidate>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Nombre:</label>
                            <input type="text" class="form-control" id="nombre" required data-validation-required-message="Ingrese su nombre">
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Teléfono:</label>
                            <input type="tel" class="form-control" id="telefono" required data-validation-required-message="Ingrese su teléfono">
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Email:</label>
                            <input type="email" class="form-control" id="email" required data-validation-required-message="Ingrese su email">
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Mensaje:</label>
                            <textarea rows="10" cols="100" class="form-control" id="mensaje" required data-validation-required-message="Ingrese su mensaje" maxlength="999" style="resize: none"></textarea>
                        </div>
                    </div>
                    <div id="exito"></div>
                    <!-- For success/fail messages -->
                    <button type="submit" class="btn btn-primary">Enviar</button>
                </form>
            </div>
            <!-- Contact Details Column -->
            <div class="col-md-4">
                <h3>Detalles</h3>
                <p>
                    Chacabuco 1020<br>
                    Córdoba, Argentina<br>
                </p>
                <p>
                    <i class="fa fa-phone"></i>
                    <abbr title="Teléfono">Tél.</abbr>: (03525) 456-7890
                </p>
                <p>
                    <i class="fa fa-envelope-o"></i>
                    <abbr title="Email">E</abbr>: <a href="mailto:davidadiaz11@gmail.com.com">jumbotron@jumbotron.com</a>
                </p>
                <p>
                    <i class="fa fa-clock-o"></i>
                    <abbr title="Horarios">H</abbr>: Lunes - Viernes: 9:00 hs. a 20:00 hs.
                </p>
                <ul class="list-unstyled list-inline list-social-icons">
                    <li>
                        <a href="#"><i class="fa fa-facebook-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-linkedin-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-twitter-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-google-plus-square fa-2x"></i></a>
                    </li>
                </ul>
            </div>
        </div>
        <!-- /.row -->
    </div>
</asp:Content>

