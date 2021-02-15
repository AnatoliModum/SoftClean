<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDiseñoReportes.aspx.cs" Inherits="AppSoftClean.Vistas.Listas.ViewDiseñoReportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.3.1.min.js"></script>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/fontawesome.css" rel="stylesheet" />
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/brands.css" rel="stylesheet" />
    <link href="https://use.fontawesome.com/releases/v5.8.1/css/solid.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../css/Style.css" type="text/css" />
    <style>
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-md-3 col-md-offset-4">
                    <div>
                        <h1>Reporte de Pedidos Por Área</h1>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div>
                        <h6>Folio de Levantamiento</h6>
                        <asp:Label ID="txtIdLevantamiento" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div>
                        <h6>División</h6>
                        <asp:Label ID="txtDivision" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div>
                        <h6>Numero de Hoja</h6>
                        <asp:Label ID="txtNoHoja" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div>
                        <h6>Fecha de Levantamiento</h6>
                        <asp:Label ID="txtFechaLevantamiento" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div = "row" >
                <div class="col-md-10 col-md-offset-1">
                    <div class="x_content">
                <div class="form-horizontal form-label-left input_mask">
                    <asp:GridView ID="dgvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="10" Width="100%" CssClass="table table-condensed table-hover" DataKeyNames="id"
                        EmptyDataText="No Existen Datos del Área Aún.">
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
                            <asp:BoundField HeaderText="Área de Instalación" DataField="AreaInstalacion" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Módelo Equipo Dosificador" DataField="ModeloEquipoDosificador" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Dosificador Estación de Limpieza" DataField="DosificadorEstacionDeLimpieza" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Productos Químicos" DataField="ProductosQuimicos" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Modelo Jabonera" DataField="ModeloJabonera" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Cepillo, Inserto y Base" DataField="CantidadConsumibles" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Tipos de Máquinas Lavavajillas" DataField="TipoMaquinaLavavajillas" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Dosificador para Lavavajillas" DataField="DosificadoresLavavajillas" ItemStyle-Font-Size="10" />
                            <asp:BoundField HeaderText="Porta Galón" DataField="PortaGalones" ItemStyle-Font-Size="10" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
                </div>
            </div>

        </div>
        
    </form>
</body>
</html>
