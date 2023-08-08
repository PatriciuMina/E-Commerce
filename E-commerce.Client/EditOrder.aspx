<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="E_commerce.Client.EditOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var urlParams = new URLSearchParams(window.location.search);
            var orderId = urlParams.get('parameter');
            console.log(orderId);

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

            $("#updateOrderButton").click(function () {
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


        });
    </script>

    <h1>Edit Order</h1>
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
                    <button type="button" id="updateOrderButton">Update Order</button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

