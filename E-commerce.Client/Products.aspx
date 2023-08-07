<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Products.aspx.cs" Inherits="E_commerce.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
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

            // Handle add button click
            $("#addProductButton").click(function () {
                var formData = {
                    User_ID: $("#user_id").val(),
                    Name: $("#name").val(),
                    Price: $("#price").val(),
                    Description: $("#description").val(),
                    Image: $("#image").val()
                };

                $.ajax({
                    url: "https://localhost:44307/api/products",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        messageDiv.text("Product added successfully.");
                        clearForm();
                        location.reload();
                        // generateUserTable(); 
                    },
                    error: function () {
                        messageDiv.text("Error adding user.");
                    }
                });
            });

            function clearForm() {
                $("#user_id").val("");
                $("#name").val("");
                $("#price").val("");
                $("#description").val("");
                $("#image").val("");
            }

        });
    </script>

     <h1>Products</h1>

     <div id="messageDiv" class=""></div>

    <h2>Add New Product</h2>

    <div id="IdRegistrationForm" runat="server">
        <table>

            <tr>
                <td><label for="user_id">User ID:</label></td>
                <td>
                    <input type="text" id="user_id" name="user_id" required><br> 
                </td>
            </tr>
            <tr>
                <td><label for="name">Name:</label></td>
                <td>
                    <input type="text" id="name" name="name" required><br>
                </td>
            </tr>
            <tr>
                <td><label for="price">Price:</label></td>
                <td>
                    <input type="number" id="price" name="price" required><br> 
                </td>
            </tr>
            <tr>
                <td><label for="description">Description:</label></td>
                <td>
                    <input type="text" id="description" name="description" required><br>
                </td>
            </tr>
            <tr>
                <td><label for="image">Image:</label></td>
                <td>
                    <input type="text" id="image" name="image" required><br>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <button type="button" id="addProductButton">Add Product</button>
                </td>
            </tr>
        </table>
    </div>
    <p></p>

    <asp:Label ID="ProductTable" runat="server"></asp:Label>

</asp:Content>
