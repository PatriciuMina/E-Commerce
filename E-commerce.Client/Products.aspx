<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Products.aspx.cs" Inherits="E_commerce.WebForm1" %>

<%@ Register Src="~/Controls/ProductsControl.ascx" TagPrefix="uc1" TagName="ProductsControl" %>

<%@ Register Src="~/Controls/ProductsControl.ascx" TagPrefix="uc" TagName="ProductsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Layouts/TableStyle.css" rel="stylesheet" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var messageDiv = $("#messageDiv");

            // Delete button action
            $(document).on("click", ".delete-button", function () {
                var productId = $(this).data("id");
                console.log(productId);
                deleteProduct(productId);
            });

            // Function to delete a product using AJAX
            function deleteProduct(productId) {
                $.ajax({
                    url: "https://localhost:44307/api/products/" + productId,
                    type: "DELETE",
                    success: function () {
                        messageDiv.text("Product deleted successfully.");
                        location.reload();
                    },
                    error: function () {
                        messageDiv.text("Error deleting user.");
                    }
                });
            }

            // Edit button redirect
            $(document).on("click", ".edit-button", function () {
                var productId = $(this).data("id");
                console.log(productId);
                window.location.href = "EditProduct.aspx?parameter=" + productId;
            });
        });
    </script>

    <h1>Products</h1>

    <div id="messageDiv" class=""></div>

    <h2>Add New Product</h2>

    <uc:ProductsForm ID="ProductsControl" runat="server" />

    <asp:Label ID="ProductTable" runat="server"></asp:Label>

</asp:Content>
