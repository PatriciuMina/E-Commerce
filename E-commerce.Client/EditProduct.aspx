<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="E_commerce.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var urlParams = new URLSearchParams(window.location.search);
            var productId = urlParams.get('parameter');
            console.log(productId);

            // Pre-fill data with previous data 
            $.ajax({
                url: "https://localhost:44307/api/products/" + productId,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $("#user_id").val(data.User_ID);
                    $("#name").val(data.Name);
                    $("#price").val(data.Price);
                    $("#description").val(data.Description);
                    $("#image").val(data.Image); 
                },
                error: function () {
                    // Handle error
                }
            });

            $("#updateProductButton").click(function () {
                var formData = {
                    User_ID: $("#user_id").val(),
                    Name: $("#name").val(),
                    Price: $("#price").val(),
                    Description: $("#description").val(),
                    Image: $("#image").val()
                };

                $.ajax({
                    url: "https://localhost:44307/api/products/" + productId,
                    type: "PUT",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        window.location.href = "Products.aspx";
                    },
                    error: function () {
                        window.location.href = "Products.aspx";
                    }
                });
            });


        });
    </script>

    <h1>Edit Product</h1>

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
                    <button type="button" id="updateProductButton">Update Product</button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
