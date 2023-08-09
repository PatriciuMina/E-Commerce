<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="E_commerce.Client.EditOrder" %>

<%@ Register Src="~/Controls/OrdersControl.ascx" TagPrefix="uc1" TagName="OrdersControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Order</h1>

    <uc1:OrdersControl runat="server" ID="OrdersControl" />
    
</asp:Content>

