﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Products.aspx.cs" Inherits="E_commerce.WebForm1" %>

<%@ Register Src="~/Controls/ProductsControl.ascx" TagPrefix="uc1" TagName="ProductsControl" %>

<%@ Register Src="~/Controls/ProductsControl.ascx" TagPrefix="uc" TagName="ProductsForm" %>
<%@ Register Src="~/Controls/TablesControl.ascx" TagPrefix="uc" TagName="TablesControl" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <link href="../Layouts/TableStyle.css" rel="stylesheet" />

    <h1>Products</h1>

    <h2>Add New Product</h2>

    <uc1:ProductsControl ID="ProductsControl" runat="server" />

    <uc:TablesControl runat="server" ID="TablesControl" /> 
</asp:Content>
