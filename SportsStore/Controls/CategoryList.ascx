<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="SportsStore.Controls.CategoryList" %>

<%=CreateHomeLinkHtml() %>

<% foreach (var category in GetCategories())
   {
       Response.Write(CreateLinkHtml(category));
   } %>