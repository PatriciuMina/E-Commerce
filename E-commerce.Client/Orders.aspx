<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Orders.aspx.cs" Inherits="E_commerce.Client.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var messageDiv = $("#messageDiv");

            // Delete button action
            $(document).on("click", ".delete-button", function () {
                var orderId = $(this).data("id");
                console.log(orderId);
                deleteOrder(orderId);
            });

            // Function to delete an order using AJAX
            function deleteOrder(orderId) {
                $.ajax({
                    url: "https://localhost:44307/api/orders/" + orderId,
                    type: "DELETE",
                    success: function () {
                        messageDiv.text("Order deleted successfully.");
                        location.reload();
                    },
                    error: function () {
                        messageDiv.text("Error deleting user.");
                    }
                });
            }

            // Edit button redirect
            $(document).on("click", ".edit-button", function () {
                var ordereId = $(this).data("id");
                console.log(ordereId);
                window.location.href = "EditOrder.aspx?parameter=" + ordereId;
            });

            // Handle add button click
            $("#addOrderButton").click(function () {
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
                        messageDiv.text("Order added successfully.");
                        clearForm();
                        location.reload();
                    },
                    error: function () {
                        messageDiv.text("Error adding user.");
                    }
                });
            });

            function clearForm() {
                $("#user_id").val("");
                $("#date").val("");
                $("#total").val("");
                $("#address_id").val("");
            }

        });
    </script>
     <h1>Orders</h1>

     <div id="messageDiv" class=""></div>

    <h2>Add New Order</h2>

    <div id="IdRegistrationForm" runat="server">
        <table>

            <tr>
                <td><label for="user_id">User ID:</label></td>
                <td>
                    <input type="text" id="user_id" name="user_id" required><br> 
                </td>
            </tr>
            <tr>
                <td><label for="date">Date:</label></td>
                <td>
                    <input type="date" id="date" name="date" required><br>
                </td>
            </tr>
            <tr>
                <td><label for="total">Total:</label></td>
                <td>
                    <input type="number" id="total" name="total" required><br> 
                </td>
            </tr>
            <tr>
                <td><label for="address_id">Address ID:</label></td>
                <td>
                    <input type="text" id="address_id" name="address_id" required><br> 
                </td>
            </tr>
           
            <tr>
                <td colspan="2">
                    <button type="button" id="addOrderButton">Add Order</button>
                </td>
            </tr>
        </table>
    </div>
    <p></p>

    <asp:Label ID="OrderTable" runat="server"></asp:Label>

</asp:Content>


