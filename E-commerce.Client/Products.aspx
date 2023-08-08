<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Products.aspx.cs" Inherits="E_commerce.WebForm1" %>

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

    <div id="IdRegistrationForm" runat="server" class="field form-group">
        <label for="user_id">User ID:</label>
        <input type="text" id="user_id" name="user_id" required class="form-control"><br>

        <label for="name">Name:</label>
        <input type="text" id="name" name="name" required class="form-control"><br>

        <label for="price">Price:</label>
        <input type="number" id="price" name="price" required class="form-control"><br>

        <label for="description">Description:</label>
        <input type="text" id="description" name="description" required class="form-control"><br>

        <label for="image">Image:</label>
        <input type="text" id="image" name="image" required class="form-control"><br>

        <button type="button" id="addProductButton" class="btn btn-secondary rounded-3">Add Product</button>
    </div>
    <p></p>

    <asp:Label ID="ProductTable" runat="server"></asp:Label>

</asp:Content>
