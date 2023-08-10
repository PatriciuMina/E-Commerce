<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Addresses.aspx.cs" Inherits="E_commerce.Client.Addresses" %>

<%@ Register Src="~/Controls/AddressesControl.ascx" TagPrefix="uc" TagName="AddressesControl" %>


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
        });

    </script>

      <h1>Addresses</h1>

    <div id="messageDiv" class=""></div>
    
    <h2>Add New Address</h2>
   
  <uc:AddressesControl ID="AddressesControl" runat="server" />

    <asp:Label ID="AddressTable" runat="server"></asp:Label>
    
</asp:Content>