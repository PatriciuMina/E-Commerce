<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TablesControl.ascx.cs" Inherits="E_commerce.Client.Controls.TablesControl" %>
<link href="../Layouts/TableStyle.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {

        var tablesParameter = window.location.pathname;
        switch (tablesParameter) {
            case "/Products/Products":
                editLinkString = "/Products/EditProduct.aspx?parameter=";
                deleteUrlString = "https://localhost:44343/api/products/";
                break;
            case "/Orders/Orders":
                editLinkString = "/Orders/EditOrder.aspx?parameter=";
                deleteUrlString = "https://localhost:44343/api/orders/";
                break;
            case "/Users/Users":
                editLinkString = "/Users/EditUser.aspx?userId=";
                deleteUrlString = "https://localhost:44343/api/users/";
                break;
            case "/Addresses/Addresses":
                editLinkString = "/Addresses/EditAddress.aspx?addressId=";
                deleteUrlString = "https://localhost:44343/api/address/";
                break;
        }

        // Delete button action
        $(document).on("click", ".delete-button", function () {
            var Id = $(this).data("id");
            deleteItem(Id);
        });
        
        // Function to delete a product using AJAX
        function deleteItem(Id) {
            $.ajax({
                url: deleteUrlString + Id,
                type: "DELETE",
                success: function () {
                    console.log("Item deleted successfully.");
                    location.reload();
                },
                error: function () {
                    console.log("Error deleting user.");
                }
            });
        }
          
        // Edit button redirect
        $(document).on("click", ".edit-button", function () {
            var Id = $(this).data("id");
            window.location.href = editLinkString + Id;
        });

        // View Product Button Redirect
        $(document).on("click", ".btn-primary", function () {
            var Id = $(this).data("id"); 
            window.location.href = "../Products/ViewProduct.aspx?parameter=" + Id;
        });

        
    });

</script>

<asp:Label ID="Table" runat="server"></asp:Label>
