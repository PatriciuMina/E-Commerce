<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="E_commerce.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="IdRegistrationForm" runat="server">
         <table>
            <tr>
                <td>User ID</td>
                <td>
                    <asp:TextBox ID="UserID" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="Name" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Price</td>
                <td>
                    <asp:TextBox ID="Price" runat="server" type="number" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="Description" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Image</td>
                <td>
                    <asp:TextBox ID="Image" runat="server" ></asp:TextBox>
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
