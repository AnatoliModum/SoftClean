﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDosLav.aspx.cs" Inherits="AppSoftClean.Vistas.FormAreaUso" %>

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
        <div class="col-lg-12">
            <h1>Dosificador para Lavavajillas <span class="badge bg-secondary">Nuevo</span></h1>
        </div>
    </div>
    <div class="panel panel-info panel-inicial">
        <div class="panel-heading">
            <h3 class="panel-title"><span><i class="fas fa-pencil-alt"></i></span>&nbsp; Registrar Información </h3>
        </div>
        <div class="panel-body">
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
                    <a class="btn btn-success" href="#"><i class="fas fa-trash-alt"></i>&nbsp;Guardar</a>
                </div>
                <div class="col-lg-2">
                    <a class="btn btn-danger" href="#"><i class="fas fa-trash-alt"></i>&nbsp;Cancelar</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
