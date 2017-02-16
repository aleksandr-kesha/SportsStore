using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        private readonly Repository _repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (!IsPostBack)
                return;

            var order = new Order();

            if (!TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
                return;

            order.OrderLines = new List<OrderLine>();

            var cart = SessionHelper.GetCart(Session);

            foreach (var line in cart.Lines)
            {
                order.OrderLines.Add(new OrderLine
                {
                    Product = line.Product,
                    Order = order,
                    Quantity = line.Quantity
                });
            }

            _repository.SaveOrder(order);

            cart.Clear();

            checkoutForm.Visible = false;
            checkoutMessage.Visible = true;
        }
    }
}