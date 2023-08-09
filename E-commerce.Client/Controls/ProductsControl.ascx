<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsControl.ascx.cs" Inherits="E_commerce.Client.Controls.WebUserControl1" %>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<link href="Layouts/TableStyle.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {

        var urlParams = new URLSearchParams(window.location.search);
        var productId = urlParams.get('parameter');
        console.log(productId);
        if (productId != null) {
            var productButton = document.getElementById("addProduct");
            productButton.textContent = "Edit Product"
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

            $("#addProduct").click(function () {
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

        } else {
            var productButton = document.getElementById("addProduct");
            productButton.textContent = "Add Product"
            // Handle add button click
            $("#addProduct").click(function () {
                var formData = {
                    User_ID: $("#user_id").val(),
                    Name: $("#name").val(),
                    Price: $("#price").val(),
                    Description: $("#description").val(),
                    Image: $("#image").val()
                };
                console.log(formData);

                $.ajax({
                    url: "https://localhost:44307/api/products",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        console.log("Product added successfully.");
                        clearForm();
                        location.reload();
                        // generateUserTable(); 
                    },
                    error: function () {
                        console.log("Error adding user.");
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
        }
    });


</script>

<div id="IdRegistrationForm" runat="server" class="field form-group">
    <label for="user_id1">User ID:</label>
    <input type="text" id="user_id" name="user_id" required class="form-control"><br>

    <label for="name1">Name:</label>
    <input type="text" id="name" name="name" required class="form-control"><br>

    <label for="price1">Price:</label>
    <input type="number" id="price" name="price" required class="form-control"><br>

    <label for="description1">Description:</label>
    <input type="text" id="description" name="description" required class="form-control"><br>

    <label for="image1">Image:</label>
    <input type="text" id="image" name="image" required class="form-control"><br>

    <button type="button" id="addProduct" class="btn btn-secondary rounded-3">Add Product</button>
</div>
<p></p>
