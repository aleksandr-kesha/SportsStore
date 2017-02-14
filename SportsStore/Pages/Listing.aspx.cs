using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private readonly Repository _repository;

        private int _pageSize = 4;

        protected Listing()
        {
            _repository = new Repository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            int selectedProductId;

            if (!int.TryParse(Request.Form["add"], out selectedProductId))
                return;

            var selectedProduct = _repository.Products.FirstOrDefault(p => p.ProductId == selectedProductId);

            if (selectedProduct != null)
            {
                SessionHelper.GetCart(Session).AddItem(selectedProduct,1);
                SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);
                // ReSharper disable once PossibleNullReferenceException
                
                //var path = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
                //Response.Redirect(path);
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts()
                .OrderBy(p => p.ProductId)
                .Skip((CurrentPage - 1)*_pageSize)
                .Take(_pageSize);
        }

        private IEnumerable<Product> FilterProducts()
        {
            var products = _repository.Products;

            var category = (string) RouteData.Values["category"] ?? Request.QueryString["category"];

            return !string.IsNullOrWhiteSpace(category)
                ? products.Where(
                    p => string.Compare(p.Category, category, StringComparison.CurrentCultureIgnoreCase) == 0)
                : products;
        }

        protected int CurrentPage
        {
            get
            {
                var page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        private int GetPageFromRequest()
        {
            int page;

            var reqValue = (string) RouteData.Values["page"] ?? Request.QueryString["page"];

            return !string.IsNullOrEmpty(reqValue) && int.TryParse(reqValue, out page) ? page : 1;
        }

        protected int MaxPage => (int) Math.Ceiling((decimal) FilterProducts().Count()/_pageSize);
    }
}