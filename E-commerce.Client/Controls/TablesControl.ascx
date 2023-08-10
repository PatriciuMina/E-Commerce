<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TablesControl.ascx.cs" Inherits="E_commerce.Client.Controls.TablesControl" %>

<h1>Table Control</h1>
<script type="text/javascript">
    $(document).ready(function () {

        var tablesParameter = window.location.pathname;
        
        if (tablesParameter == "/Products") {
            console.log("AAAAAAAAAAAAAAAAAAAAAAAAA");
          

        } else {   
        }
    });


</script>

<asp:Label ID="Table" runat="server"></asp:Label>
