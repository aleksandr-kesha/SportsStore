<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="SportsStore.Pages.CartView" MasterPageFile="Store.Master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="bodyContent">
    <div id="content">
        <h2>Your cart</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Item</th>
                    <th>Quantity</th>
                    <th>Price</th>
                    <th>Subtotal</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ItemType="SportsStore.Models.CartLine" SelectMethod="GetCartLines" EnableViewState="False">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Product.Name %></td>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Product.Price.ToString("c") %></td>
                            <td><%# Item.Total.ToString("c") %></td>
                            <td>
                                <button type="submit" runat="server" value="<%#Item.Product.ProductId %>" class="actionButtons" name="remove">Remove</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Total:</td>
                    <td><%= CartTotal.ToString("c")%></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons"><a href="<%= ReturnUrl %>">Continue shopping</a></p>
    </div>
</asp:Content>
