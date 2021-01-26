<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AppSoftClean.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>

</head>
<body>
    <div class="container">
        <form runat="server">
            <div id="loginbox" style="margin-top: 13rem;" class="mainbox col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1">
               <div class="panel panel-primary">
    
                   <div class="panel-body">
                       <div class="col-lg-6">
                           <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Imagen.png" />
                       </div>
                       <div class="col-lg-6">
                           <h1 style="text-align: center">Hotel Gran Regina</h1>
                           <h4 style="text-align: center; margin-bottom: 25px">Sistema de Reportes y Control de Inventario </h4>
                           <div style="margin-bottom: 25px" class="input-group">
                               <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                               <asp:TextBox ID="TextUser" runat="server" CssClass="form-control" Required="Required" placeholder="Usuario"></asp:TextBox>
                           </div>
                           <div style="margin-bottom: 25px" class="input-group">
                               <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                               <asp:TextBox ID="TextPass" runat="server" TextMode="Password" required="requered" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                           </div>
                           <div class="col-lg-12 col-lg-offset-5">
                           <asp:Button ID="BtnEntrar" runat="server" CssClass="btn btn-primary" Width="225px" Text="Entrar" OnClick="BtnEntrar_Click"/>                           </div>
                       </div>
                   </div>
               </div>
            </div>
        </form>
    </div>
</body>
</html>
