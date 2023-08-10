<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="E_commerce.Client.EditUser" %>

<%@ Register Src="~/Controls/UsersControl.ascx" TagPrefix="uc" TagName="UsersControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit User</h1>

    <h1>User Control</h1>

    <uc:UsersControl runat="server" ID="UsersControl" />
   
</asp:Content>