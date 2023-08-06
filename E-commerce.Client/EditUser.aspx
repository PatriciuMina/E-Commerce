<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="E_commerce.Client.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <h1>Edit User</h1>

    <div id="messageDiv" class=""></div>
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

    <button type="button" id="updateUserButton">Update User</button>

    <script>
        $(document).ready(function () {
            var urlParams = new URLSearchParams(window.location.search);
            var userId = urlParams.get('userId');

            // Pre-fill data with previous data 
            $.ajax({
                url: "https://localhost:44307/api/users/" + userId,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $("#name").val(data.Name);
                    $("#email").val(data.Email);
                    $("#phone_number").val(data.PhoneNumber);
                    $("#password").val(data.Password);
                    $("#role").val(data.Role);
                },
                error: function () {
                    // Handle error
                }
            });

            $("#updateUserButton").click(function () {
                var formData = {
                    Name: $("#name").val(),
                    Email: $("#email").val(),
                    PhoneNumber: $("#phone_number").val(),
                    Password: $("#password").val(),
                    Role: $("#role").val()
                };

                $.ajax({
                    url: "https://localhost:44307/api/users/" + userId,
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

            
        });
    </script>
</asp:Content>