<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrivateChat.aspx.cs" Inherits="E_commerce.Client.Chat.PrivateChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #messageContainer {
            border: 1px solid #ccc;
            width: 100%;
            height: 70%;
            overflow-y: scroll;
        }

        .message {
            background-color: #f2f2f2;
            padding: 10px;
            margin: 5px;
            border-radius: 10px;
            width: 50%;
        }

        .user1 {
            position: relative;
            background-color: #4CAF50;
            color: white;
            text-align: right;
            margin-left: auto;
            margin-right: 0;
            top: 10px;
            bottom: 10px;
            right: 10px;
        }

        .user2 {
            position: relative;
            background-color: #3498db;
            color: white;
            top: 10px;
            bottom: 10px;
            left: 10px;
        }

        .bg-dark {
            background-color: #343a40;
            width: 100%;
            height: 700px;
            position: relative;
        }

        .input-field {
            background-color: #f2f2f2;
            position: absolute;
            bottom: 0px;
            padding: 10px;
            margin: 5px;
            border-radius: 10px;
            width: 88%;
        }

        .buttton-send {
            background-color: #f2f2f2;
            position: absolute;
            bottom: 0px;
            right: 10px;
            width: 10%;
            padding: 10px;
            margin: 5px;
            border-radius: 10px;
        }
    </style>

    <div class="container-fluid">
        <div class="bg-dark">
            <asp:Label ID="Messages" runat="server"></asp:Label>
            <asp:TextBox ID="messageInput" runat="server" CssClass="input-field"></asp:TextBox>
            <asp:Button ID="sendButton" runat="server" Text="Send Message" OnClick="SendMessage" CssClass="buttton-send" />
        </div>
    </div>   
</asp:Content>
