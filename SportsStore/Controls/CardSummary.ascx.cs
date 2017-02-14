using System;
using System.Linq;
using System.Web.Routing;
using SportsStore.Pages.Helpers;

namespace SportsStore.Controls
{
    public partial class CardSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myCart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = myCart.Lines.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = myCart.ComputeTotalValue().ToString("c");
            // ReSharper disable once PossibleNullReferenceException
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
        }
    }
}