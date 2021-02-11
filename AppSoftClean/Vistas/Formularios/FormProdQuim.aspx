<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormProdQuim.aspx.cs" Inherits="AppSoftClean.Vistas.FormProdQuim" %>

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
            <h1>Productos Químicos</h1>
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
                    <asp:RequiredFieldValidator ID="rfvQuimico" runat="server" ValidationGroup="VDProdQuim"
                        ControlToValidate="TextQuimico"
                        ErrorMessage="El Nombre del Producto Quimico es Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <div class="input-group">
                        <span class="input-group-addon icono-color-azul input-group-azul" id="basic-addon1"><span><i class="fas fa-tag"></i></span></span>
                        <asp:TextBox ID="TextQuimico" runat="server" CssClass="form-control text-border-azul" placeholder="Quimico"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="revQuimico" runat="server" ValidationGroup="VDProdQuim"
                        ErrorMessage="Solo Ingrese Letras"
                        ValidationExpression="^[a-zA-ZÀ-ÿ ]*$"
                        ControlToValidate="TextQuimico"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="col-lg-4">
                    <asp:RequiredFieldValidator ID="rfvStock" runat="server" ValidationGroup="VDProdQuim"
                        ControlToValidate="TextStock"
                        ErrorMessage="El Stock es Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <div class="input-group">
                        <span class="input-group-addon icono-color-azul input-group-azul" id="basic-addon2"><span><i class="fas fa-list-ol"></i></span></span>
                        <asp:TextBox ID="TextStock" runat="server" CssClass="form-control text-border-azul" placeholder="Stock"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="revStock" runat="server" ValidationGroup="VDProdQuim"
                        ErrorMessage="Solo Ingrese Números"
                        ValidationExpression="\d*\.?\d*"
                        ControlToValidate="TextStock"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="col-lg-4">
                    <asp:UpdatePanel ID="UpdateValidacion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblErrorDDL" runat="server" Visible="false" style="padding-bottom:1px" CssClass="label label-danger" Text="Seleccione un Área"></asp:Label>
                            <asp:Label ID="lblMargen" runat="server" style="padding-bottom:1px" CssClass="label label-success" Text="Por Favor Elija una Opción"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDL_AreaUso" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="input-group">
                        <span class="input-group-addon icono-color-azul input-group-azul" id="basic-addon3"><span><i class="fas fa-arrow-circle-down"></i></span></span>
                        <asp:DropDownList ID="DDL_AreaUso" runat="server" CssClass="form-control text-border-azul" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DDL_AreaUso_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1">
            <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="VDProdQuim" />
        </div> 
        <div class="col-lg-2">
            <asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </div>

</asp:Content>
