<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="E_commerce.Client.EditOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="IdRegistrationForm" runat="server">
           <table>

            <tr>
                <td>User ID</td>
                <td>
                    <asp:TextBox ID="UserID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Date</td>
                <td>
                    <asp:TextBox ID="Date" runat="server" type="date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Total</td>
                <td>
                    <asp:TextBox ID="Total" runat="server" type="number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address_Id</td>
                <td>
                    <asp:TextBox ID="Address_Id" runat="server"></asp:TextBox>
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

