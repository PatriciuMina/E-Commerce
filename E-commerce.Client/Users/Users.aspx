<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Users.aspx.cs" Inherits="E_commerce.Client.Users" %>

<%@ Register Src="~/Controls/UsersControl.ascx" TagPrefix="uc" TagName="UsersControl" %>
<%@ Register Src="~/Controls/TablesControl.ascx" TagPrefix="uc" TagName="TablesControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <link href="../Layouts/TableStyle.css" rel="stylesheet" />
    <h1>Users</h1>

    <div id="messageDiv" class=""></div>

    <h2>Add New User</h2>

    <uc:UsersControl ID="UsersControl" runat="server" />

    <uc:TablesControl runat="server" ID="TablesControl" />

</asp:Content>
