<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="itApp.Default" %>

<!DOCTYPE html>

<head runat="server">
    <title>Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-image:url(img/colorful.jpg); background-repeat: no-repeat; background-attachment: fixed">
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
    <div class="container" >
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Login</legend>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Usuario" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="UserBox" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label ID="Label6" runat="server" Text="Contraseña" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="PasswordBox" TextMode="Password" runat="server" placeholder="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnLogin_Click"/>                          
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>

    </form>
</body>
</html>
