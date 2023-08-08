<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Addresses.aspx.cs" Inherits="E_commerce.Client.Addresses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Layouts/TableStyle.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Addresses</h1>

    <div id="messageDiv" class=""></div>
    
    <h2>Add New Address</h2>
    <div id="addAddressForm" class="field form-group">
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

        <button type="button" id="addAddressButton" class="btn btn-secondary rounded-3">Add Address</button>
    </div>
  <div id="addressContainer"></div>

    <asp:Label ID="AddressTable" runat="server"></asp:Label>
    <script>
        $(document).ready(function () {
            var messageDiv = $("#messageDiv");

            // Delete button action
            $(document).on("click", ".delete-button", function () {
                var addressId = $(this).data("id");
                deleteAddress(addressId);
            });

            // Function to delete an address using AJAX
            function deleteAddress(addressId) {
                $.ajax({
                    url: "https://localhost:44307/api/address/" + addressId,
                    type: "DELETE",
                    success: function () {
                        messageDiv.text("Address deleted successfully.");
                        location.reload();
                    },
                    error: function () {
                        messageDiv.text("Error deleting address.");
                    }
                });
            }
            // Edit button redirect
            $(document).on("click", ".edit-button", function () {
                var addressId = $(this).data("id");
                window.location.href = "EditAddress.aspx?addressId=" + addressId;
            });

            // Handle add button click
            $("#addAddressButton").click(function () {
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
                    url: "https://localhost:44307/api/address",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        messageDiv.text("Address added successfully.");
                        clearForm();
                        location.reload();
                        generateAddressTable(); // not working
                    },
                    error: function () {
                        messageDiv.text("Error adding address.");
                    }
                });
            });

            function clearForm() {
                $("#user_id").val("");
                $("#address_line1").val("");
                $("#address_line2").val("");
                $("#city").val("");
                $("#postal_code").val("");
                $("#country").val("");
                $("#region").val("");
            }

        });

    </script>
    
</asp:Content>