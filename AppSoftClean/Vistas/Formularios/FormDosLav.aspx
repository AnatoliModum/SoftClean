<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDosLav.aspx.cs" Inherits="AppSoftClean.Vistas.FormDosLav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/fontawesome.css" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/brands.css" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/solid.css" rel="stylesheet">
    <link rel="stylesheet" href="../css/Style.css" type="text/css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <h1>Dosificador para Lavavajillas</h1>
        </div>
        <div class="col-lg-2">
            <h2><span class="label label-info"><asp:Label ID="lblAccion" runat="server" Text="Label"></asp:Label></span></h2>
        </div>
    </div>
    <div class="panel panel-info panel-inicial">
        <div class="panel-heading">
            <h3 class="panel-title"><span><i class="fas fa-pencil-alt"></i></span>&nbsp; Registrar Información </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-4">
                    <asp:RequiredFieldValidator ID="rfvEquipo" runat="server" ValidationGroup="VDDosLav"
                        ControlToValidate="TextEquipo"
                        ErrorMessage="El Nombre del Equipo es Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-lg-5">
                    <asp:RequiredFieldValidator ID="rfvStock" runat="server" ValidationGroup="VDDosLav"
                        ControlToValidate="TextStock"
                        ErrorMessage="El Stock es Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon1"><span><i class="fas fa-tag"></i></span></span>
                        <asp:TextBox ID="TextEquipo" runat="server" CssClass="form-control" placeholder="Nombre del Equipo"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-5">
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon2"><span><i class="fas fa-bookmark"></i></span></span>
                        <asp:TextBox ID="TextStock" runat="server" CssClass="form-control" placeholder="Stock"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-1">
                    <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="VDDosLav" />
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:RegularExpressionValidator ID="revEquipo" runat="server" ValidationGroup="VDDosLav"
                        ErrorMessage="Solo Ingrese Letras"
                        ValidationExpression="^[a-zA-Z ]*$"
                        ControlToValidate="TextEquipo"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="col-lg-5">
                    <asp:RegularExpressionValidator ID="revStock" runat="server" ValidationGroup="VDDosLav"
                        ErrorMessage="Solo Ingrese Números"
                        ValidationExpression="\d*\.?\d*"
                        ControlToValidate="TextStock"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
