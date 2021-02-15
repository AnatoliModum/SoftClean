<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUsuarios.aspx.cs" Inherits="AppSoftClean.Vistas.Listas.ViewUsuarios" %>

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
        function MyModalCreate() {

            $("#MyModalCreate").modal("show");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- DataGrid de la Lista de Levantamiento de Equipos --%>
    <div class="col-md-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <br>
                <div class="row">
                    <div class="col-lg-10">
                        <h2 style="margin-top: 0px"><asp:Image ID="ImgLista" CssClass="icono" ImageUrl="~/Imagenes/lista.png" runat="server" />&nbsp Lista de Usuarios</h2>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="BtnCrear" class="btn btn-info" runat="server" Text="Crear" OnClick="BtnCrear_Click" />
                    </div>
                    <div class="col-lg-1" style="margin-left: -14px">
                        <asp:Button ID="BtnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" />
                    </div>
                </div>
            </div>
                    <div class="x_content">
                        <div class="form-horizontal form-label-left input_mask">
                            <asp:GridView ID="dgvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="10" Width="100%" CssClass="table table-bordered bs-table" DataKeyNames="id"
                                EmptyDataText="No Existen Datos del Área Aún." OnRowCommand="dgvDatos_RowCommand">
                                <HeaderStyle BackColor="#5bc0de" Font-Size="9" ForeColor="White" />
                                <%--Configuracion de la cabecera--%>
                                <AlternatingRowStyle BackColor="#c0e7f9" Font-Size="10" ForeColor="#4C4C4C" />
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
                                    <asp:BoundField HeaderText="Usuario" DataField="usuario" ItemStyle-Font-Size="10" />
                                    <asp:BoundField HeaderText="Correo" DataField="correo" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Font-Size="10" />
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
                    <h4>Confirme para eliminar el registro número&nbsp<span class="label label-danger"><asp:Label ID="lblID" runat="server" Text="Label"></asp:Label></span>&nbsp llamado &nbsp<span class="label label-danger"><asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label></span></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                </div>
            </div>
        </div>
    </div>  

    <%--Modal que se encarga de crear los datos--%>
    <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-hidden="true" id="MyModalCreate">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <div class="modal-header modal-header-success">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="myModalCreate"><i class="fas fa-plus-circle"></i>&nbsp Crear</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <asp:UpdatePanel ID="UpdateValidacionModal" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdateValidacion" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="lblErrorDDL" runat="server" Visible="false" Style="padding-bottom: 1px" CssClass="label label-danger" Text="Seleccione una División"></asp:Label>
                                            <asp:Label ID="lblMargen" runat="server" Style="padding-bottom: 1px" CssClass="label label-success" Text="Por Favor Elija una Opción"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DDL_Categorias" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnCrear_Modal" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon3"><span><i class="fas fa-bookmark"></i></span></span>
                                <asp:DropDownList ID="DDL_Categorias" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DDL_Categorias_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon15"><span><i class="far fa-user-alt"></i></span></span>
                                <asp:TextBox ID="TextUser" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon2"><span><i class="fas fa-bookmark"></i></span></span>
                                <asp:TextBox ID="TextPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnCrear_Modal" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Modal_Click" ValidationGroup="VDLevanEqui" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
