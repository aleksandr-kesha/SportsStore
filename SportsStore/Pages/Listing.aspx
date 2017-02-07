<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="SportsStore.Pages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sports Server</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <% foreach (var product in GetProducts())
                {
                    Response.Write("<div class='item'>");
                    Response.Write($"<h3>{product.Name}</h3>");
                    Response.Write(product.Description);
                    Response.Write($"<h4>{product.Price.ToString("c")}</h4>");
                    Response.Write("</div>");
                } %>
        </div>
    </form>
    <div>
        <% for (var i = 1; i <= MaxPage; i++)
           {
               Response.Write($"&nbsp <a href='/Pages/Listing.aspx?page={i}' {(i == CurrentPage ? "class='selected'" : "")} > {i} </a>");
           } %>
    </div>
</body>
</html>
