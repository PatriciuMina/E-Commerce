<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Users.aspx.cs" Inherits="E_commerce.Client.Users" %>

<%@ Register Src="~/Controls/UsersControl.ascx" TagPrefix="uc" TagName="UsersControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Layouts/TableStyle.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<script>
    $(document).ready(function () {
        var messageDiv = $("#messageDiv");

        // Delete button action
        $(document).on("click", ".delete-button", function () {
            var userId = $(this).data("id");
            console.log(userId);
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
            console.log(userId);
            window.location.href = "EditUser.aspx?userId=" + userId;
        });
    });
</script>

    <h1>Users</h1>

    <div id="messageDiv" class=""></div>

    <h2>Add New User</h2>

    <uc:UsersControl ID="UsersControl" runat="server" />

    <asp:Label ID="UserTable" runat="server"></asp:Label>

</asp:Content>
