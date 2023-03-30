
using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace BikeLibrary.BLL

{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static List<Item> GetObjectFromJson(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(List<Item>) : JsonSerializer.Deserialize<List<Item>>(value);

        }
    }
}
