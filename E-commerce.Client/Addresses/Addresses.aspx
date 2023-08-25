<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addresses.aspx.cs" Inherits="E_commerce.Client.Addresses.Addresses" %>

<%@ Register Src="~/Controls/AddressesControl.ascx" TagPrefix="uc1" TagName="AddressesControl" %>
<%@ Register Src="~/Controls/TablesControl.ascx" TagPrefix="uc1" TagName="TablesControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <link href="../Layouts/TableStyle.css" rel="stylesheet" />
    
     <h1>Addresses</h1>

    <div id="messageDiv" class=""></div>

    <h2>Add New Address</h2>

    <uc1:AddressesControl runat="server" ID="AddressesControl" />

    <uc1:TablesControl runat="server" ID="TablesControl" />
</asp:Content>
