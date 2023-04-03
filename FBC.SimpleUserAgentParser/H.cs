using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FBC.SimpleUserAgentParser
{
    internal static class H
    {
        /// <summary>
        /// ed
        /// </summary>
        /// <param name="str"></param>
        /// <param name="caseInsensitive"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool StartsWithOneOfThese(this string str, bool caseInsensitive = false, params string[] args)
        {
            foreach (var arg in args)
            {
                if (caseInsensitive && str.ToLower().StartsWith(arg.ToLower()))
                {
                    return true;
                }
                if (!caseInsensitive && str.StartsWith(arg))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///  Case Sensitive
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool StartsWithOneOfThese(this string str, params string[] args)
        {
            return StartsWithOneOfThese(str, caseInsensitive: false, args);
        }
        /// <summary>
        /// Case Sensitive
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string? AnyStartsWith(this IEnumerable<string> collection, string str )
        {
            return collection.FirstOrDefault( x => x.StartsWith(str));
        }
        /// <summary>
        /// Case Sensitive
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string? AnyStartsWithOneOfThese(this IEnumerable<string> collection, params string[] args)
        {
            return collection.FirstOrDefault(x => x.StartsWithOneOfThese(args));
        }

        static JsonSerializerOptions JsonSerializationOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        static JsonSerializerOptions JsonDeserializationOptions = new JsonSerializerOptions
        {
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            Converters = { new JsonStringEnumConverter() }
        };
        internal static string ToJson(this object o)
        {
            return o == null ? "null" : JsonSerializer.Serialize(o, JsonSerializationOptions);
        }

        internal static T? FromJson<T>(this string json)
        {
            return string.IsNullOrEmpty(json) || json.Trim().ToLower() == "null"
                ? default
                : JsonSerializer.Deserialize<T>(json, JsonDeserializationOptions);
        }
    }
}
