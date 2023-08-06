<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Users.aspx.cs" Inherits="E_commerce.Client.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Users</h1>

    <div id="messageDiv" class=""></div>

    <h2>Add New User</h2>
    <div id="addUserForm">
        <label for="name">Name:</label>
        <input type="text" id="name" name="name" required><br>

        <label for="email">Email:</label>
        <input type="text" id="email" name="email" required><br>

        <label for="phone_number">Phone Number:</label>
        <input type="text" id="phone_number" name="phone_number"><br>

        <label for="password">Password:</label>
        <input type="text" id="password" name="password"><br>

        <label for="role">Role:</label>
        <input type="text" id="role" name="role" required><br>

        <button type="button" id="addUserButton">Add User</button>
    </div>
     <div id="userContainer"></div>

        <asp:Label ID="UserTable" runat="server"></asp:Label>

<script>
    $(document).ready(function () {
        var messageDiv = $("#messageDiv");

        // Delete button action
        $(document).on("click", ".delete-button", function () {
            var userId = $(this).data("id");
            deleteUser(userId);
        });

        // Function to delete a user using AJAX
        function deleteUser(userId) {
            $.ajax({
                url: "https://localhost:44307/api/users/" + userId,
                type: "DELETE",
                success: function () {
                    messageDiv.text("User deleted successfully.");
                    location.reload();
                },
                error: function () {
                    messageDiv.text("Error deleting user.");
                }
            });
        }

        // Edit button redirect
        $(document).on("click", ".edit-button", function () {
            var userId = $(this).data("id");
            window.location.href = "EditUser.aspx?userId=" + userId;
        });

        // Handle add button click
        $("#addUserButton").click(function () {
            var formData = {
                Name: $("#name").val(),
                Email: $("#email").val(),
                PhoneNumber: $("#phone_number").val(),
                Password: $("#password").val(),
                Role: $("#role").val()
            };

            $.ajax({
                url: "https://localhost:44307/api/users",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(formData),
                success: function () {
                    messageDiv.text("User added successfully.");
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
            $("#name").val("");
            $("#email").val("");
            $("#phone_number").val("");
            $("#password").val("");
            $("#role").val("");
        }

    });
</script>

</asp:Content>
