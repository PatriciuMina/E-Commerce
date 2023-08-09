<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrdersControl.ascx.cs" Inherits="E_commerce.Client.Controls.OrdersControl" %>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<link href="Layouts/TableStyle.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        var urlParams = new URLSearchParams(window.location.search);
        var orderId = urlParams.get('parameter');
        if (orderId != null) {
            var orderButton = document.getElementById("OrderButton");
            orderButton.textContent = "Edit Order";
            // Pre-fill data with previous data 
            $.ajax({
                url: "https://localhost:44307/api/orders/" + orderId,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $("#user_id").val(data.User_ID);
                    $("#date").val(data.Date);
                    $("#total").val(data.Total);
                    $("#address_id").val(data.Address_Id);
                },
                error: function () {
                    // Handle error
                }
            });

            $("#OrderButton").click(function () {
                var formData = {
                    User_ID: $("#user_id").val(),
                    Date: $("#date").val(),
                    Total: $("#total").val(),
                    Address_Id: $("#address_id").val(),
                };

                $.ajax({
                    url: "https://localhost:44307/api/orders/" + orderId,
                    type: "PUT",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        window.location.href = "Orders.aspx";
                    },
                    error: function () {
                        window.location.href = "Orders.aspx";
                    }
                });
            });
        } else {
            var orderButton = document.getElementById("OrderButton");
            orderButton.textContent = "Add Order";
            // Handle add button click
            $("#OrderButton").click(function () {
                var formData = {
                    User_ID: $("#user_id").val(),
                    Date: $("#date").val(),
                    Total: $("#total").val(),
                    Address_Id: $("#address_id").val(),
                };


                $.ajax({
                    url: "https://localhost:44307/api/orders",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        console.log("Order added successfully.");
                        clearForm();
                        location.reload();
                    },
                    error: function () {
                        console.log("Error adding user.");
                    }
                });
            });

            function clearForm() {
                $("#user_id").val("");
                $("#date").val("");
                $("#total").val("");
                $("#address_id").val("");
            }

        }
    });
</script>

<div id="IdRegistrationForm" runat="server" class="field form-group">
    <label for="user_id">User ID:</label>
    <input type="text" id="user_id" name="user_id" required class="form-control"><br>

    <label for="date">Date:</label>
    <input type="date" id="date" name="date" required class="form-control"><br>

    <label for="total">Total:</label>
    <input type="number" id="total" name="total" required class="form-control"><br>

    <label for="address_id">Address ID:</label>
    <input type="text" id="address_id" name="address_id" required class="form-control"><br>

    <button type="button" id="OrderButton" class="btn btn-secondary rounded-3">Add Order</button>

</div>
<p></p>
