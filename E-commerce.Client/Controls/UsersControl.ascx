<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersControl.ascx.cs" Inherits="E_commerce.Client.Controls.UsersControl" %>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<link href="Layouts/TableStyle.css" rel="stylesheet" />

<script type="text/javascript">
    $(document).ready(function () {

        var urlParams = new URLSearchParams(window.location.search);
        var userId = urlParams.get('userId');
        console.log(userId);
        if (userId != null) {
            var userButton = document.getElementById("userButton");
            userButton.textContent = "Edit User"
           
            // Pre-fill data with previous data 
            $.ajax({
                url: "https://localhost:44343/api/users/" + userId,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $("#name").val(data.UserName);
                    $("#email").val(data.Email);
                    $("#phone_number").val(data.PhoneNumber);
                    $("#password").val(data.Password);
                    //$("#role").val(data.Role);
                },
                error: function () {
                    // Handle error
                }
            });

            $("#userButton").click(function () {
                var formData = {
                    Name: $("#name").val(),
                    Email: $("#email").val(),
                    PhoneNumber: $("#phone_number").val(),
                    Password: $("#password").val(),
                   // Role: $("#role").val()
                };

                $.ajax({
                    url: "https://localhost:44343/api/users/" + userId,
                    type: "PUT",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        window.location.href = "Users.aspx";
                    },
                    error: function () {
                        window.location.href = "Users.aspx";
                    }
                });
            });

        } else {
            var userButton = document.getElementById("userButton");
            userButton.textContent = "Add User"
            // Handle add button click
            $("#userButton").click(function () {
                var formData = {
                    Name: $("#name").val(),
                    Email: $("#email").val(),
                    PhoneNumber: $("#phone_number").val(),
                    Password: $("#password").val(),
                    //Role: $("#role").val()
                };
                console.log(formData);

                $.ajax({
                    url: "https://localhost:44343/api/users",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        location.reload();
                        messageDiv.text("User added successfully.");
                        clearForm(); 
                        // generateUserTable(); 
                    },
                    error: function () {
                        location.reload();
                        messageDiv.text("Error adding user.");
                    }
                });
            });

            function clearForm() {
                $("#name").val("");
                $("#email").val("");
                $("#phone_number").val("");
                $("#password").val("");
               // $("#role").val("");
            }
        }
    });


</script>


<div id="IdRegistrationForm" runat="server" class="field form-group">
      <label for="name">Name:</label>
      <input type="text" id="name" name="name" required class="form-control"><br>

      <label for="email">Email:</label>
      <input type="text" id="email" name="email" required class="form-control"><br>

      <label for="phone_number">Phone Number:</label>
      <input type="text" id="phone_number" name="phone_number" required class="form-control"><br>

      <label for="password">Password:</label>
      <input type="text" id="password" name="password" required class="form-control"><br>

      <label for="role">Role:</label>
      <input type="text" id="role" name="role" required class="form-control"><br>

    <button type="button" id="userButton" class="btn btn-secondary rounded-3">Add User</button>
</div>
<p></p>