<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Users.aspx.cs" Inherits="E_commerce.Client.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="IdRegistrationForm" runat="server">
        <table>

            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td>
                    <asp:TextBox ID="PhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>Role</td>
                <td>
                    <asp:TextBox ID="Role" runat="server"></asp:TextBox>
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
        <asp:GridView ID="grvUser" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" OnRowCommand="grvUser_RowCommand">
            <HeaderStyle BackColor="#00aaaa"></HeaderStyle>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" />
                <asp:BoundField DataField="Role" HeaderText="Role" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" OnClick="EditUser_Click" data-argument='<%# Eval("Id") %>' Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="DeleteBtn" OnClick="DeleteUser_Click" data-argument='<%# Eval("Id") %> ' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
