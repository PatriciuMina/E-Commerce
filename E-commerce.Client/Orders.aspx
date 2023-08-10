<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Orders.aspx.cs" Inherits="E_commerce.Client.Orders" %>

<%@ Register Src="~/Controls/OrdersControl.ascx" TagPrefix="uc1" TagName="OrdersControl" %>
<%@ Register Src="~/Controls/TablesControl.ascx" TagPrefix="uc1" TagName="TablesControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Layouts/TableStyle.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            // Delete button action
            $(document).on("click", ".delete-button", function () {
                var orderId = $(this).data("id");
                deleteOrder(orderId);
            });

            // Function to delete an order using AJAX
            function deleteOrder(orderId) {
                $.ajax({
                    url: "https://localhost:44307/api/orders/" + orderId,
                    type: "DELETE",
                    success: function () {
                        console.log("Order deleted successfully.");
                        location.reload();
                    },
                    error: function () {
                        console.log("Error deleting user.");
                    }
                });
            }

            // Edit button redirect
            $(document).on("click", ".edit-button", function () {
                var ordereId = $(this).data("id");
                window.location.href = "EditOrder.aspx?parameter=" + ordereId;
            });

        });
    </script>
     <h1>Orders</h1>

    <h2>Add New Order</h2>

    <uc1:OrdersControl runat="server" ID="OrdersControl" />

    <asp:Label ID="OrderTable" runat="server"></asp:Label>   

    <h1>Table Control Table</h1>
    <uc1:TablesControl runat="server" ID="TablesControl" />

</asp:Content>


