<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Orders.aspx.cs" Inherits="E_commerce.Client.Orders" %>

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
                    <asp:Button ID="IdSubmitBtn" OnClick="IdSubmitBtn_Click" runat="server" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
    <p></p>

    <div>
        <asp:GridView ID="grvOrder" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" OnRowCommand="grvOrder_RowCommand">
            <HeaderStyle BackColor="#00aaaa"></HeaderStyle>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="User_ID" HeaderText="User_ID" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:BoundField DataField="Address_Id" HeaderText="Address_Id" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" OnClick="EditOrder_Click" data-argument='<%# Eval("Id") %> ' Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="DeleteBtn" OnClick="DeleteOrder_Click" data-argument='<%# Eval("Id") %> ' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
