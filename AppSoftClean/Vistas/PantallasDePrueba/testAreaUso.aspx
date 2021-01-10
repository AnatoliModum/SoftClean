<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testAreaUso.aspx.cs" Inherits="AppSoftClean.Vistas.PantallasDePrueba.testAreaUso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="btnAccion" runat="server" Text="A darle" OnClick="btnAccion_Click" />
    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>

</asp:Content>
