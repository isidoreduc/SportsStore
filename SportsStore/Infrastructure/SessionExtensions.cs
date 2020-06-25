﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    // The session state feature in ASP.NET Core stores only int, string, and byte[] values. Since we want to store a Cart object, we need 
    // to define extension methods to the ISession interface, which provides access to the session state data, to serialize Cart objects
    // into JSON and convert them back
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
                ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }

    }
}
