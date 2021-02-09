<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDivisiones.aspx.cs" Inherits="AppSoftClean.Vistas.Listas.ViewDivisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.3.1.min.js"></script>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/fontawesome.css" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/brands.css" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/solid.css" rel="stylesheet">
    <link rel="stylesheet" href="../../css/Style.css" type="text/css">
    <script>
        function MyModaldata() {

            $("#MyModaldata").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <br>
                <div class="row">
                    <div class="col-lg-10">
                        <h2 style="margin-top:0px"><asp:Image ID="ImgDivisiones" CssClass="icono" ImageUrl="~/Imagenes/edificio.png" runat="server" />&nbsp Divisiones</h2>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="BtnCrear" class="btn btn-info" runat="server" Text="Crear" OnClick="BtnCrear_Click" />
                    </div>
                    <div class="col-lg-1" style="margin-left:-14px">
                        <asp:Button ID="BtnCancelar" class="btn btn-danger"  runat="server" Text="Cancelar" />
                    </div>
                </div>
            </div>
            <div class="x_content">
                <div class="form-horizontal form-label-left input_mask">
                    <asp:GridView ID="dgvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="10" Width="100%" CssClass="table table-bordered bs-table" DataKeyNames="id"
                        EmptyDataText="No Existen Datos Aún." OnRowCommand="dgvDatos_RowCommand">
                        <HeaderStyle BackColor="#5bc0de" Font-Size="9" ForeColor="White" />
                        <%--Configuracion de la cabecera--%>
                        <AlternatingRowStyle BackColor="#D1E5EE" Font-Size="10" ForeColor="#4C4C4C" />
                        <%--Configuracion de Filas Alternativas--%>
                        <EmptyDataRowStyle BackColor="#F7F7F7" BorderColor="#1ABB9C" Font-Size="11" BorderWidth="1" />
                        <%--Configuracion de filas vacias--%>
                        <FooterStyle BackColor="#4C4C4C" />
                        <%--Configuración del footer --%>
                        <RowStyle BackColor="White" Font-Size="9" />
                        <%--Configuración de la fila--%>
                        <%--configuramos las columnas del grid--%>
                        <Columns>
                            <asp:BoundField HeaderText="Identidicador" DataField="id" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-Font-Size="10" />
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Imagenes/editar.png"
                                        CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="Editar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Imagenes/eliminar.png"
                                        CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="Eliminar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%--Modal que se encarga de elimianr los datos--%>
    <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-hidden="true" id="MyModaldata">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <div class="modal-header modal-header-danger">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel"><asp:Image ID="Image1" CssClass="icono-modal" ImageUrl="~/Imagenes/trash.png" runat="server" />&nbsp Eliminar</h4>
                </div>
                <div class="modal-body">
                    <h4>Confirme para eliminar el registro número&nbsp<span class="label label-danger"><asp:Label ID="lblID" runat="server" Text="Label"></asp:Label></span>&nbsp llamado &nbsp<span class="label label-danger"><asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label></span></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
