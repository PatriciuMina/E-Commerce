<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TablesControl.ascx.cs" Inherits="E_commerce.Client.Controls.TablesControl" %>

<script type="text/javascript">
    $(document).ready(function () {

        var tablesParameter = window.location.pathname;
        switch (tablesParameter) {
            case "/Products":
                editLinkString = "EditProduct.aspx?parameter=";
                deleteUrlString = "https://localhost:44307/api/products/";
                break;
            case "/Orders":
                editLinkString = "EditOrder.aspx?parameter=";
                deleteUrlString = "https://localhost:44307/api/orders/";
                break;
            case "/Users":
                editLinkString = "EditUser.aspx?userId=";
                deleteUrlString = "https://localhost:44307/api/users/";
                break;
            case "/Addresses":
                editLinkString = "EditAddress.aspx?addressId=";
                deleteUrlString = "https://localhost:44307/api/address/";
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

        } else {   
        }
    });


</script>

<asp:Label ID="Table" runat="server"></asp:Label>
