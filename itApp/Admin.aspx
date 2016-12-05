<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="itApp.Admin" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta name="description" content="IT">
    <title>Nueva incidencia</title>
    <!-- ============ Google fonts ============ -->
    <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet'
        type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700,300,800'
        rel='stylesheet' type='text/css' />
    <!-- ============ Add custom CSS here ============ -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="custom-bootstrap-menu" class="navbar navbar-default " role="navigation">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">itApp</a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                    <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="collapse navbar-collapse navbar-menubuilder">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="/">Home</a> </li>
                </ul>
            </div>
        </div>
    </div>
    <div>
        <asp:Table ID="TableCase" runat="server" 
            Font-Size="Large" 
            HorizontalAlign="Center"
            Width="95%"
            Font-Names="Palatino"
            BackColor="AliceBlue"
            BorderColor="DarkRed"
            BorderWidth="2"
            ForeColor="Black"
            CellPadding="5"
            CellSpacing="5"
            Style="text-align: center">
            <asp:TableHeaderRow 
                runat="server" 
                ForeColor="DarkOrange"
                BackColor="Black"
                Font-Bold="true"
                CellSpacing="5"
                CellPadding="5">
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Título</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Descripción</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Solicitante</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Deadline</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Categoria</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Prioridad</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Departamento</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Fecha creación</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Estado</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Fecha resolución</asp:TableHeaderCell>
                <asp:TableHeaderCell Style="text-align: center">Responsable</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
    <div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <asp:Button ID="btnAssign" runat="server" CssClass="btn btn-primary" Text="Auto asignar" OnClick="btnAssign_Click" />
                <asp:Button ID="btnDone" runat="server" CssClass="btn btn-primary" Text="Realizada" OnClick="btnDone_Click" />
                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-warning" Text="Eliminar" OnClick="btnDelete_Click" />

            </div>

        </div>
    </div>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript">
        'use strict';

        /* ========================== */
        /* ::::::: Backstrech ::::::: */
        /* ========================== */
        // You may also attach Backstretch to a block-level element
        $.backstretch(
        [
            //"img/44.jpg",
            "img/colorful.jpg",
            //"img/34.jpg",
            //"img/images.jpg"
        ],

        {
            duration: 4500,
            fade: 1500
        }
    );
    </script>
        
    </form>
</body>
</html>
