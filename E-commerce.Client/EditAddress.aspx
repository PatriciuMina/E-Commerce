<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAddress.aspx.cs" Inherits="E_commerce.Client.EditAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Address</h1>

    <div id="messageDiv" class="field form-group"></div>

    <label for="user_id">User ID:</label>
    <input type="text" id="user_id" name="user_id" required class="form-control"><br>

    <label for="address_line1">Address Line 1:</label>
    <input type="text" id="address_line1" name="address_line1" required class="form-control"><br>

    <label for="address_line2">Address Line 2:</label>
    <input type="text" id="address_line2" name="address_line2" class="form-control"><br>

    <label for="city">City:</label>
    <input type="text" id="city" name="city" required class="form-control"><br>

    <label for="postal_code">Postal Code:</label>
    <input type="text" id="postal_code" name="postal_code" required class="form-control"><br>

    <label for="country">Country:</label>
    <input type="text" id="country" name="country" required class="form-control"><br>

    <label for="region">Region:</label>
    <input type="text" id="region" name="region" class="form-control"><br>

    <button type="button" id="updateAddressButton" class="btn btn-secondary rounded-3">Update Address</button>

    <script>
        $(document).ready(function () {

            var urlParams = new URLSearchParams(window.location.search);
            var addressId = urlParams.get('addressId');
            // pre fill data with previous data 
            $.ajax({
                url: "https://localhost:44307/api/address/" + addressId, 
                type: "GET",
                dataType: "json",
                success: function (data) {
                  
                    $("#user_id").val(data.User_Id);
                    $("#address_line1").val(data.Address_line1);
                    $("#address_line2").val(data.Address_line2);
                    $("#city").val(data.City);
                    $("#postal_code").val(data.Postal_code);
                    $("#country").val(data.Country);
                    $("#region").val(data.Region);
                },
                error: function () {
                    // Handle error
                }
            });


            $("#updateAddressButton").click(function () {

                var formData = {
                    User_Id: $("#user_id").val(),
                    Address_line1: $("#address_line1").val(),
                    Address_line2: $("#address_line2").val(),
                    City: $("#city").val(),
                    Postal_code: $("#postal_code").val(),
                    Country: $("#country").val(),
                    Region: $("#region").val()
                };

                $.ajax({
                    url: "https://localhost:44307/api/address/" + addressId, 
                    type: "PUT", 
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        window.location.href = "Addresses.aspx";
                    },
                    error: function () {
                        window.location.href = "Addresses.aspx";
                    }
                });
            });

            
        });
    </script>
</asp:Content>
