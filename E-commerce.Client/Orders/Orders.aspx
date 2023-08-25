<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Orders.aspx.cs" Inherits="E_commerce.Client.Orders" %>

<%@ Register Src="~/Controls/OrdersControl.ascx" TagPrefix="uc1" TagName="OrdersControl" %>
<%@ Register Src="~/Controls/TablesControl.ascx" TagPrefix="uc1" TagName="TablesControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <link href="../Layouts/TableStyle.css" rel="stylesheet" />

    <h1>Orders</h1>

    <h2>Add New Order</h2>

    <uc1:OrdersControl runat="server" ID="OrdersControl" />

    <uc1:TablesControl runat="server" ID="TablesControl" />

</asp:Content>
