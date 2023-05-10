
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;


namespace BikeLibrary.BLL

{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(ISession session, string key, Cart cart)
        {
            string cartJson = JsonSerializer.Serialize(cart);
            session.SetString(key, cartJson);
        }

        public static Cart GetObjectFromJson(ISession session, string key)
        {
            var value = session.GetString(key);
            if(value == null)
            {
                return new Cart();
            }
            return JsonSerializer.Deserialize<Cart>(value);
        }
    }
}
