﻿using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Models;
using SportsStore.Models.Repository;

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

        }

        protected IEnumerable<Product> GetProducts()
        {
            return _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((CurrentPage - 1)*_pageSize)
                .Take(_pageSize);
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

        protected int MaxPage => (int) Math.Ceiling((decimal) _repository.Products.Count()/_pageSize);
    }
}