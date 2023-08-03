<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCard.ascx.cs" Inherits="E_commerce.Client.ProductCard" %>


<div class="product-card">
    <img src="<%# Product.Image %>" alt="<%# Product.Name %>" />
    <h3><%# Product.Name %></h3>
    <p>$<%# Product.Price %></p>
    <asp:Button runat="server" Text="Add to Cart" OnClick="AddToCartButton_Click" />
</div>