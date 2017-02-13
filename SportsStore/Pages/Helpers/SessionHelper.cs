using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SportsStore.Models;

namespace SportsStore.Pages.Helpers
{
    public enum SessionKey
    {
        Cart,
        RETURN_URL
    }

    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof (SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            var dataValue = session[Enum.GetName(typeof (SessionKey), key)];

            if (dataValue is T)
                return (T)dataValue;

            return default(T);
        }

        public static Cart GetCart(HttpSessionState session)
        {
            var myCart = Get<Cart>(session, SessionKey.Cart);

            if (myCart == null)
            {
                myCart = new Cart();
                Set(session, SessionKey.Cart, myCart);
            }

            return myCart;
        }
    }
}