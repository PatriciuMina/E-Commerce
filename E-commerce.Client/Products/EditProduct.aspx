<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="E_commerce.EditProduct" %>

<%@ Register Src="~/Controls/ProductsControl.ascx" TagPrefix="uc1" TagName="ProductsControl" %>

<%@ Register Src="~/Controls/ProductsControl.ascx" TagPrefix="uc" TagName="ProductsForm"%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Product</h1>

    <uc1:ProductsControl runat="server" ID="ProductsControl" />

</asp:Content>

