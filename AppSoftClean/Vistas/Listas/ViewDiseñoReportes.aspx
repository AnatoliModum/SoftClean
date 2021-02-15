<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDiseñoReportes.aspx.cs" Inherits="AppSoftClean.Vistas.Listas.ViewDiseñoReportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/modernizr-2.8.3.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <style>
body {
width: 100%;
margin: 5px;
}

.table-condensed tr th {
border: 0px solid #6e7bd9;
color: white;
background-color: #6e7bd9;
}

.table-condensed, .table-condensed tr td {
border: 0px solid #000;
}

tr:nth-child(even) {
background: #f8f7ff
}

tr:nth-child(odd) {
background: #fff;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-md-3 col-md-offset-4">
                    <div class="page-header">
                        <h1>Reporte de Pedidos Por Área</h1>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div class="page-header">
                        <h6>Folio de Levantamiento</h6>
                        <asp:Label ID="txtIdLevantamiento" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div class="page-header">
                        <h6>División</h6>
                        <asp:Label ID="txtDivision" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div class="page-header">
                        <h6>Numero de Hoja</h6>
                        <asp:Label ID="txtNoHoja" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <div class="page-header">
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
