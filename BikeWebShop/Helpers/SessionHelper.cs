
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using BikeWebShop.Helpers;

namespace BikeLibrary.BLL

{
    public static class SessionHelper
    {
        //    public static void SetObjectAsJson(ISession session, string key, Cart cart)
        //    {
        //        string cartJson = JsonSerializer.Serialize(cart);
        //        session.SetString(key, cartJson);
        //    }

        //    public static Cart GetObjectFromJson(ISession session, string key)
        //    {
        //        var value = session.GetString(key);
        //        if (value == null)
        //        {
        //            return new Cart();
        //        }
        //        return JsonSerializer.Deserialize<Cart>(value);
        //    }

        public static void SetObjectAsJson(ISession session, string key, Cart cart)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new CouponConverter());
            string cartJson = JsonSerializer.Serialize(cart, options);
            session.SetString(key, cartJson);
        }

        public static Cart GetObjectFromJson(ISession session, string key)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new CouponConverter());

            var value = session.GetString(key);
            if (value == null)
            {
                return new Cart();
            }

            return JsonSerializer.Deserialize<Cart>(value, options);
        }
    }
}
