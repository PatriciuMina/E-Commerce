<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAddress.aspx.cs" Inherits="E_commerce.Client.EditAddress" %>

<%@ Register Src="~/Controls/AddressesControl.ascx" TagPrefix="uc" TagName="AddressesControl" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Address</h1>

    <h1>Address Control</h1>

    <uc:AddressesControl ID="AddressesControl" runat="server" />

</asp:Content>
