<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" MasterPageFile="Store.Master" Inherits="SportsStore.Pages.Listing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <% foreach (var product in GetProducts())
            {
                Response.Write("<div class='item'>");
                Response.Write($"<h3>{product.Name}</h3>");
                Response.Write(product.Description);
                Response.Write($"<h4>{product.Price.ToString("c")}</h4>");
                Response.Write("</div>");
            } %>
    </div>

    <div class="pager">
        <% for (var i = 1; i <= MaxPage; i++)
            {
                Response.Write($"&nbsp <a href='/Pages/Listing.aspx?page={i}' {(i == CurrentPage ? "class='selected'" : "")} > {i} </a>");
            } %>
    </div>

</asp:Content>
