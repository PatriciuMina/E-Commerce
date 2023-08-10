<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Addresses.aspx.cs" Inherits="E_commerce.Client.Addresses" %>

<%@ Register Src="~/Controls/AddressesControl.ascx" TagPrefix="uc" TagName="AddressesControl" %>
<%@ Register Src="~/Controls/TablesControl.ascx" TagPrefix="uc" TagName="TablesControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Layouts/TableStyle.css" rel="stylesheet" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Addresses</h1>

    <div id="messageDiv" class=""></div>

    <h2>Add New Address</h2>

    <uc:AddressesControl ID="AddressesControl" runat="server" />

    <uc:TablesControl runat="server" ID="TablesControl" />
</asp:Content>
