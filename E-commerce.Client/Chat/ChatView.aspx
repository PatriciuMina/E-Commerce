<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChatView.aspx.cs" Inherits="E_commerce.Client.ChatView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <div class="container text-center">
        <div class="card border-dark rounded-3">
            <div class="card-header">
                <h3>All your conversations</h3>
            </div>
            <div class="card-body">
                <div>
                    <button class="btn btn-primary rounded-4">
                       <a href="../Chat/StartChat.aspx" style="color: white;">Start a conversation</a>
                    </button>
                </div>
            </div>
        </div>
        <br />
        <asp:Label ID="Conversations" runat="server"></asp:Label>
    </div>




</asp:Content>
