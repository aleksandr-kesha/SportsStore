using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        private readonly Repository _repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            int productId;

            if(!int.TryParse(Request.Form["remove"], out productId))
                return;

            var productToRemove = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if(productToRemove != null)
                SessionHelper.GetCart(Session).RemoveLine(productToRemove);

        }

        public IEnumerable<CartLine> GetCartLines() => SessionHelper.GetCart(Session).Lines;

        public decimal CartTotal => SessionHelper.GetCart(Session).ComputeTotalValue();

        public string ReturnUrl => SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
    }
}