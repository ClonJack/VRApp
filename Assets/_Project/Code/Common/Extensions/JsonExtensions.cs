using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnrealTeam.Common.Extensions
{
    public static class JsonExtensions
    {
        public static T FromJson<T>(this string jsonString) 
            => JsonConvert.DeserializeObject<T>(jsonString);

        public static string ToJson<T>(this T obj) 
            => JsonConvert.SerializeObject(obj, Formatting.Indented, 
                new JsonSerializerSettings 
                { 
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                });

        public static T GetValueOrDefault<T>(this JObject jObject, string key, T defaultValue = default) 
            => jObject.TryGetValue(key, out JToken jToken) 
                ? jToken.ToObject<T>() 
                : defaultValue;

        public static T GetValueOrDefault<T>(this JObject jObject, string key, Func<T> defaultValueGetter) 
            => jObject.TryGetValue(key, out JToken jToken) 
                ? jToken.ToObject<T>() 
                : defaultValueGetter.Invoke();

        public static T GetNestedValueOrDefault<T>(this JObject jObject, string key, T defaultValue = default)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken != null 
                ? jToken.ToObject<T>() 
                : defaultValue;
        }
        
        public static bool HasValue(this JObject jObject, string key)
            => jObject.TryGetValue(key, out _);
    }
}