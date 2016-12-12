<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseQuestionnaire.aspx.cs" Inherits="itApp.CaseQuestionnaire" %>

<!DOCTYPE html>

<head runat="server">
    <meta charset="utf-8">
    <title>Nueva incidencia</title>

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
                    <li><a href="Admin.aspx">Administrar</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container" >
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Nueva incidencia <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Título" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TitleBox" runat="server" placeholder="Título" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label ID="Label6" runat="server" Text="Descripción" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="DescriptionBox" runat="server" placeholder="Descripción" CssClass="form-control"
                                    TextMode="MultiLine" Rows="3"> </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Deadline" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="height: 230px">
                                <asp:Calendar ID="DeadlineCalendar" runat="server" style="margin-top: 0px" CssClass="form-control"></asp:Calendar>
                            </div>
                            <asp:Label ID="Label4" runat="server" Text="Departamento" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <div class="radio">
                                    <label>
                                        <br />
                                        <asp:RadioButtonList ID="DepartmentRadioButton" runat="server" RepeatColumns="2" Width="80%">
                                            <asp:ListItem>Desarrollo</asp:ListItem>
                                            <asp:ListItem>Administración</asp:ListItem>
                                            <asp:ListItem>Contabilidad</asp:ListItem>
                                            <asp:ListItem>QA</asp:ListItem>
                                            <asp:ListItem>Helpdesk</asp:ListItem>
                                            <asp:ListItem>Sistemas</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="Categoria" CssClass="col-lg-2 control-label"></asp:Label>                          
                            <div class="col-lg-10">
                                <asp:DropDownList ID="CategoryDropDownList" runat="server" CssClass="form-control ddl">
                                    <asp:ListItem>Instalación Software</asp:ListItem>
                                    <asp:ListItem>Creación/Modificación entorno</asp:ListItem>
                                    <asp:ListItem>Otros</asp:ListItem>
                                </asp:DropDownList>                              
                            </div>
                            <asp:Label ID="Label5" runat="server" Text="Prioridad" CssClass="col-lg-2 control-label"></asp:Label>                          
                            <div class="col-lg-10">
                                <asp:DropDownList ID="PriorityDropDownList" runat="server" CssClass="form-control ddl">
                                    <asp:ListItem>Baja</asp:ListItem>
                                    <asp:ListItem>Media</asp:ListItem>
                                    <asp:ListItem>Alta</asp:ListItem>
                                </asp:DropDownList>                              
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnSubmit_Click"/>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Cancelar" OnClick="btnCancel_Click"/>                              
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
