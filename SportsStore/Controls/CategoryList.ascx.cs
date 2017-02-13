using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using SportsStore.Models.Repository;

namespace SportsStore.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        private readonly Repository _repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string CreateHomeLinkHtml()
        {
            var path = RouteTable.Routes.GetVirtualPath(null, null)?.VirtualPath;
            return $"<a href='{path}'>Home</a>";
        }

        protected IEnumerable<string> GetCategories()
        {
            return _repository.Products.Select(p => p.Category).Distinct().OrderBy(c => c);
        }

        protected string CreateLinkHtml(string category)
        {
            var selectdCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];

            var path =
                RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary {{"category", category}, {"page", "1"}})?.VirtualPath;

            return
                $"<a href='{path}' {(string.Compare(category, selectdCategory, StringComparison.CurrentCultureIgnoreCase) == 0 ? "class='selected'" : "")}>{category}</a>";
        }
    }
}