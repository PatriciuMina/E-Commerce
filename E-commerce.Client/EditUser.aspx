<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="E_commerce.Client.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="IdRegistrationForm" runat="server">
         <table>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="Name" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="Email" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td>
                    <asp:TextBox ID="PhoneNumber" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="Password" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Role</td>
                <td>
                    <asp:TextBox ID="Role" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="IdSubmitBtn" OnClick="IdEditBtn_Click" runat="server" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>