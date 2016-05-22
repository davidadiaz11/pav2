<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Header Carousel -->
    <header id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <div class="fill" style="background-image: url('img/slide1.gif');"></div>
                <div class="carousel-caption">
                    <h2>Tomate El Palo</h2>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image: url('img/slide2.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Gastate Todo </h2>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image: url('img/slide3.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Buscate Un Curro En Finlandia</h2>
                </div>
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </header>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Content -->
    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Bienvenidos a Jumbotron !
                </h1>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-check"></i>Hoteles</h4>
                    </div>
                    <div class="panel-body">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                        <a href="Hotel.aspx" class="btn btn-default">Ver más</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-gift"></i>Viajes</h4>
                    </div>
                    <div class="panel-body">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                        <a href="Viaje.aspx" class="btn btn-default">Ver más</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-compass"></i>Paquetes</h4>
                    </div>
                    <div class="panel-body">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                        <a href="#" class="btn btn-default">Ver más</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Section -->



        <div class="row">
            <div class="col-md-3">
                <p class="lead">Paises</p>
                <div class="list-group">
                    <asp:Repeater ID="rpt_Paises" runat="server">
                        <ItemTemplate>
                            <a href='Viaje.aspx?id=<%# Eval("id") %>' class="list-group-item"><%# Eval("descripcion") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="col-lg-12">
                <h2 class="page-header">Promociones</h2>
            </div>
            <div>   
                <asp:Repeater ID="rpt_Viajes" runat="server" OnItemCommand="rpt_Viajes_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 col-sm-6">
                        <div class="thumbnail">
                            <img class="img-responsive img-portfolio img-hover" src="img/<%# Eval("imagen") %>.jpg" alt="">
                            <div class="caption">

                                <h4><a href="#"><%# Eval("descripcion") %></a>
                                </h4>
                                <asp:Button ID="btnComprar" runat="server" Text="Comprar" CssClass="btn btn-primary" CommandArgument='<%#Eval("id") %>' CommandName="Comprar" />
                                <asp:Button ID="btnVer" runat="server" Text="Ver" CommandName="Ver" CssClass="btn" CommandArgument='<%#Eval("id")%>' />
                                <h4 class="pull-right"><%# Eval("precio","{0:c}") %></h4>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div>
            
        </div>

        <!-- /.row -->

        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Modern Business Features</h2>
            </div>
            <div class="col-md-6">
                <p>The Modern Business template by Start Bootstrap includes:</p>
                <ul>
                    <li><strong>Bootstrap v3.2.0</strong>
                    </li>
                    <li>jQuery v1.11.0</li>
                    <li>Font Awesome v4.1.0</li>
                    <li>Working PHP contact form with validation</li>
                    <li>Unstyled page elements for easy customization</li>
                    <li>17 HTML pages</li>
                </ul>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Corporis, omnis doloremque non cum id reprehenderit, quisquam totam aspernatur tempora minima unde aliquid ea culpa sunt. Reiciendis quia dolorum ducimus unde.</p>
            </div>
            <div class="col-md-6">
                <img class="img-responsive" src="http://placehold.it/700x450" alt="">
            </div>
        </div>
        <!-- /.row -->

        <hr>

        <!-- Call to Action Section -->
        <div class="well">
            <div class="row">
                <div class="col-md-8">
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Molestias, expedita, saepe, vero rerum deleniti beatae veniam harum neque nemo praesentium cum alias asperiores commodi.</p>
                </div>
                <div class="col-md-4">
                    <a class="btn btn-lg btn-default btn-block" href="#">Call to Action</a>
                </div>
            </div>
        </div>

        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Jumbotron 2016</p>
                </div>
            </div>
        </footer>

    </div>
    <!-- /.container -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Script to Activate the Carousel -->
    <script>
        $('.carousel').carousel({
            interval: 5000 //changes the speed
        })
    </script>
</asp:Content>

