<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AppSoftClean.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>
    <div class="container">
        <form runat="server">
            <div id="loginbox" style="margin-top: 50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel">
                    <div class="panel-heading" style="background-color:#AA0001">
                        <div class="panel-title" style="color: white">Login</div>
                        <div style="float: right; font-size: 80%; position: relative; top: -10px;"><asp:Label runat="server" style="color: white">Olvidaste tu Password?</asp:Label></div>
                    </div>

                    <div style="padding-top: 30px" class="panel-body">

                        <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12"></div>

                        <div id="loginform" class="form-horizontal" role="form">

                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ErrorMessage="Solo es permitido ingresar correos gmail o hotmail" ControlToValidate="TextEmail" Font-Bold="True" Font-Size="Medium" ForeColor="#000066" ValidationExpression="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[gmail||hotmail]+[.][com]{1,5}"></asp:RegularExpressionValidator>

                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email" Required="Required" placeholder="email"></asp:TextBox>
                            </div>


                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox ID="TextContraseña" runat="server" TextMode="Password" required="requered" CssClass="form-control" placeholder="password"></asp:TextBox>
                            </div>


                            <div style="margin-top: 10px" class="form-group">
                                <!-- Button -->
                                <div class="col-sm-12 col-lg-offset-10 controls">
                                     <%--<asp:Button ID="BtnEntrar" style="background-color:#AA0001; color: white" runat="server" CssClass="btn" Text="Entrar" OnClick="BtnEntrar_Click"/>--%>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-12 control">
                                    <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                        No tienes una cuenta! 
                                        <a href="agregar.aspx" style="color: #AA0001">Vamos a crearla
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
