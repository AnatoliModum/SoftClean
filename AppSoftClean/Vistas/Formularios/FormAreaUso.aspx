<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAreaUso.aspx.cs" Inherits="AppSoftClean.Vistas.FormAreaUso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.3.1.min.js"></script>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/fontawesome.css" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/brands.css" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/solid.css" rel="stylesheet">
    <link rel="stylesheet" href="../../css/Style.css" type="text/css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <h1>Área de Uso</h1>
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
                    <asp:RequiredFieldValidator ID="rfvArea" runat="server" ValidationGroup="VDArea"
                        ControlToValidate="TextArea"
                        ErrorMessage="El Nombre del Área es Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <div class="input-group">
                        <span class="input-group-addon icono-color-azul input-group-azul" id="basic-addon1"><span><i class="fas fa-tag"></i></span></span>
                        <asp:TextBox ID="TextArea" runat="server" CssClass="form-control text-border-azul" placeholder="Área"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="revArea" runat="server" ValidationGroup="VDArea"
                        ErrorMessage="Solo Ingrese Letras"
                        ValidationExpression="^[a-zA-ZÀ-ÿ ]*$"
                        ControlToValidate="TextArea"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="col-lg-5">
                    <div class="input-group margen">
                        <span class="input-group-addon icono-color-azul input-group-azul" id="basic-addon2"><span><i class="fas fa-bookmark"></i></span></span>
                        <asp:TextBox ID="TextDescripcion" runat="server" class="form-control text-border-azul" Rows="1" placeholder="Descripción"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="revDescripcion" runat="server" ValidationGroup="VDArea"
                        ErrorMessage="Solo Ingrese Letras y Números"
                        ValidationExpression="^[A-Z0-9À-ÿ a-z]*$"
                        ControlToValidate="TextDescripcion"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="col-lg-1 margen">
                    <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="VDArea" />
                </div>
                <div class="col-lg-2 margen">
                    <asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
