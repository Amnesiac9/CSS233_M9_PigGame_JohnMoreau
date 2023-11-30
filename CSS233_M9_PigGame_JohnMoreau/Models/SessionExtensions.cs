using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace CSS233_M9_PigGame_JohnMoreau.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var valueJson = session.GetString(key);
            if (string.IsNullOrEmpty(valueJson))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(valueJson);
        }
    }
}
