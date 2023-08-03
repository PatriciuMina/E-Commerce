<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Products.aspx.cs" Inherits="E_commerce.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function DeleteProduct_Click(productId) {
            $.ajax({
                type: 'DELETE',
                url: 'https://localhost:44307/api/products/' + productId,
                dataType: 'json',
                crossDomain: true,
                success: function (data, textStatus, xhr) {
                    console.log("A MERS!");
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log('Error in Operation');
                }
            });
        }

        function EditProduct_Click(productId) {
            window.location.href = "EditProduct.aspx?parameter=" + productId
        }
    </script>

    <div id="IdRegistrationForm" runat="server">
        <table>

            <tr>
                <td>User ID</td>
                <td>
                    <asp:TextBox ID="UserID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Price</td>
                <td>
                    <asp:TextBox ID="Price" runat="server" type="number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="Description" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Image</td>
                <td>
                    <asp:TextBox ID="Image" runat="server"></asp:TextBox>
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
        <asp:GridView ID="grvProduct" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" OnRowCommand="grvProduct_RowCommand">
            <HeaderStyle BackColor="#00aaaa"></HeaderStyle>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="User_ID" HeaderText="User_ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Image" HeaderText="Image" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" OnClick="EditProduct_Click" data-argument='<%# Eval("Id") %> ' Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="DeleteBtn" OnClick="DeleteProduct_Click" data-argument='<%# Eval("Id") %> ' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <p></p>

    <asp:Label ID="ProductTable" runat="server"></asp:Label>



</asp:Content>
