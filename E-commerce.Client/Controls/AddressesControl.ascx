<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressesControl.ascx.cs" Inherits="E_commerce.Client.Controls.AddressesControl" %>

<script src="Scripts/jquery-3.4.1.min.js"></script>
<link href="Layouts/TableStyle.css" rel="stylesheet" />

<script type="text/javascript">
    $(document).ready(function () {

        var urlParams = new URLSearchParams(window.location.search);
        var addressId = urlParams.get('addressId');
        console.log(addressId);
        if (addressId != null) {
            var addressButton = document.getElementById("addressButton");
            addressButton.textContent = "Edit Address"
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

            $("#addressButton").click(function () {

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

        } else {
            var addressButton = document.getElementById("addressButton");
            addressButton.textContent = "Add Address"
            // Handle add button click
            $("#addressButton").click(function () {
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
                        location.reload();
                        messageDiv.text("Address added successfully.");
                        clearForm();
                        //generateAddressTable(); // not working
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
        }
    });


</script>

 <div id="IdRegistrationForm" class="field form-group">
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
        <input type="text" id="region" name="region" required class="form-control"><br>

        <button type="button" id="addressButton" class="btn btn-secondary rounded-3">Add Address</button>
</div>
<p></p>