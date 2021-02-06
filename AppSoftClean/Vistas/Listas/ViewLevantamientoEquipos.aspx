<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewLevantamientoEquipos.aspx.cs" Inherits="AppSoftClean.Vistas.Listas.ViewLevantamientoEquipos" %>

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
        function MyModalCreate() {

            $("#MyModalCreate").modal("show");
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
                        <h2 style="margin-top: 0px">Levantamiento de Equipos Dosificadores</h2>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="BtnCrear" class="btn btn-primary" runat="server" Text="Crear" OnClick="BtnCrear_Click" />
                    </div>
                    <div class="col-lg-1" style="margin-left: -14px">
                        <asp:Button ID="BtnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">
                        <div class="input-group">
                            <span class="input-group-addon" id="basic-addon4"><span><i class="fas fa-bookmark"></i></span></span>
                            <asp:DropDownList ID="DDL_Division" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="input-group">
                            <span class="input-group-addon" id="basic-addon15"><span><i class="far fa-calendar-alt"></i></span></span>
                            <asp:TextBox ID="TextFecha" runat="server" CssClass="form-control" placeholder="Elige una Fecha"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender TargetControlID="TextFecha" ID="CalendarExtender" runat="server" Format="dd/MM/yyyy" ClearTime="True" />
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="input-group">
                            <span class="input-group-addon" id="basic-addon2"><span><i class="fas fa-bookmark"></i></span></span>
                            <asp:TextBox ID="TextNumHoja" runat="server" CssClass="form-control" placeholder="Equipos Disponibles"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <%-- DataGrid de Levantamiento de Equipos --%>
            <div class="x_content">
                <div class="form-horizontal form-label-left input_mask">
                    <asp:GridView ID="dgvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="10" Width="100%" CssClass="table table-bordered bs-table" DataKeyNames="id"
                        EmptyDataText="No Existen Datos del Área Aún." OnRowCommand="dgvDatos_RowCommand">
                        <HeaderStyle BackColor="#1ABB9C" Font-Size="9" ForeColor="White" />
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
                            <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Área de Instalación" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Módelo Equipo Dosificador" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Dosificador Estación de Limpieza" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Productos Químicos" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Modelo Jabonera" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Cepillo, Inserto y Base" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Tipos de Máquinas Lavavajillas" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Dosificador para Lavavajillas" DataField="" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Porta Galón" DataField="" ItemStyle-Font-Size="10" />

                            <asp:BoundField HeaderText="No. Hoja" DataField="NumHoja" ItemStyle-Font-Size="10" />
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

    <%--Modal que se encarga de mostar y editar los datos--%>
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-hidden="true" id="MyModalCreate">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel"><i class="fas fa-plus-circle"></i>&nbsp Crear</h4>
                </div>
                <div class="modal-body">

                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home"><i class="fas fa-store"></i>&nbsp Área de Instalación</a></li>
                        <li><a data-toggle="tab" href="#menu1">Modelo Equipo Dosificador</a></li>
                        <li><a data-toggle="tab" href="#menu2">Dosificador Estación de Limpieza</a></li>
                        <li><a data-toggle="tab" href="#menu3">Productos Químicos</a></li>
                        <li><a data-toggle="tab" href="#menu4">Modelo Jabonera</a></li>
                        <li><a data-toggle="tab" href="#menu5">Cepillo, Inserto y Base</a></li>
                        <li><a data-toggle="tab" href="#menu6">Tipo de Máquinas Lavavajillas</a></li>
                        <li><a data-toggle="tab" href="#menu7">Dosificador para Lavavajillas</a></li>
                        <li><a data-toggle="tab" href="#menu8">Porta galón</a></li>
                    </ul>

                    <div class="tab-content">
                        <div id="home" class="tab-pane fade in active">
                            <h3>Área de Instalación</h3>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="basic-addon3"><span><i class="far fa-building"></i></span></span>
                                        <asp:DropDownList ID="DDL_ÁreaInstalación" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="menu1" class="tab-pane fade">
                            <h3>Modelo Equipo Dosificador</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <span class="label label-info" style="padding-bottom:1px">Elige una Cantidad</span>
                                    <asp:DropDownList ID="DDL_CanAreasInstalacion" runat="server" CssClass="form-control" AppendDataBoundItems="true" >
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-8">
                                    <span class="label label-info" style="padding-bottom:1px">Elige un Módelo</span>
                                    <asp:DropDownList ID="DDL_AreasInstalacion" runat="server" CssClass="form-control" AppendDataBoundItems="true" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="menu2" class="tab-pane fade">
                            <h3>Dosificador Estación de Limpieza</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <span class="label label-info" style="padding-bottom:1px">Elige una Cantidad</span>
                                    <asp:DropDownList ID="CanDosEstLim" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-8">
                                    <span class="label label-info" style="padding-bottom:1px">Elige un Dosificador</span>
                                    <asp:DropDownList ID="DDL_DosEstLim" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="menu3" class="tab-pane fade">
                            <h3>Productos Químicos</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <textarea id="TxArProdQuim" class="form-control" cols="20" rows="2"></textarea>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="DDL_ProdQuim" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <div class="col-lg-1">
                                    <asp:Button ID="BtnAgregar" CssClass="btn btn-success" runat="server" Text="Agregar" />
                                </div>
                                <div class="col-lg-1">
                                    <asp:Button ID="BtnQuitar" CssClass="btn btn-danger" runat="server" Text="Quitar" />
                                </div>
                            </div>
                        </div>
                        <div id="menu4" class="tab-pane fade">
                            <h3>Modelo Jabonera</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <span class="label label-info" style="padding-bottom:1px">Ingresa una Cantidad</span>
                                    <asp:TextBox ID="TextCanModJab" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-8">
                                    <span class="label label-info" style="padding-bottom:1px">Elige un Módelo</span>
                                    <asp:DropDownList ID="DDL_ModJab" runat="server" CssClass="form-control" AppendDataBoundItems="true" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="menu5" class="tab-pane fade">
                            <h3>Cepillo, Inserto y Base</h3>
                            <div class="row">
                                <div class="col-lg-3">
                                    <span class="label label-info" style="padding-bottom:1px">Ingresa una Cantidad</span>
                                    <asp:TextBox ID="TextCanConsumibles" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <span class="label label-warning" style="padding-bottom:1px">Se Modificara</span>
                                    <asp:TextBox ID="TextCepillo" CssClass="form-control" Text="Cepillo" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <span class="label label-warning" style="padding-bottom:1px">Se Modificara</span>
                                    <asp:TextBox ID="TextInserto" CssClass="form-control" Text="Inserto" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <span class="label label-warning" style="padding-bottom:1px">Se Modificara</span>
                                    <asp:TextBox ID="TextBase" CssClass="form-control" Text="Base" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="menu6" class="tab-pane fade">
                            <h3>Tipo de Máquinas Lavavajillas</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <span class="label label-info" style="padding-bottom:1px">Ingresa una Cantidad</span>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-8">
                                    <span class="label label-info" style="padding-bottom:1px">Elige un Módelo</span>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AppendDataBoundItems="true" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="menu7" class="tab-pane fade">
                            <h3>Dosificador para Lavavajillas</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <textarea id="TxArDosLav" class="form-control" cols="20" rows="2"></textarea>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <div class="col-lg-1">
                                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Agregar" />
                                </div>
                                <div class="col-lg-1">
                                    <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="Quitar" />
                                </div>
                            </div>
                        </div>
                        <div id="menu8" class="tab-pane fade">
                            <h3>Porta galón</h3>
                            <div class="row">
                                <div class="col-lg-4">
                                    <span class="label label-info" style="padding-bottom:1px">Ingresa una Cantidad</span>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-8">
                                    <span class="label label-info" style="padding-bottom:1px">Elige un Módelo</span>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AppendDataBoundItems="true" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
