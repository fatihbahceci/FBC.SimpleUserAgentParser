using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FBC.SimpleUserAgentParser
{
    internal struct UserAgentStringMatch
    {
        public bool IsSuccess;
        public string Part1;
        public string Part2;
        public string Part3;
        public string MatchedFullValue;
    }
    internal static class H
    {
        public static UserAgentStringMatch TryParseAgentString(this string? agentString)
        {
            //string defiiniton: not contains parantheses and white space
            if (!string.IsNullOrEmpty(agentString))
            {
                //(string)/(numbersanddotsonly)(any)
                if (Regex.Match(agentString, @"^([^\(\)\s\/]+)\/([\d.]+)(.*)") is Match m && m.Success)
                {
                    return new UserAgentStringMatch()
                    {
                        IsSuccess = true,
                        Part1 = m.Groups[1].Value.Trim(),
                        Part2 = m.Groups[2].Value.Trim(),
                        Part3 = m.Groups[3].Value.Trim(),
                        MatchedFullValue = m.Value
                    };
                }
                //(string)/([can starts with a space]string)(any)
                else if (Regex.Match(agentString, @"^([^\(\)\s]+)\/(\s?[^\(\)\s]+)\s?(.*)$") is Match m2 && m2.Success)
                {
                    return new UserAgentStringMatch()
                    {
                        IsSuccess = true,
                        Part1 = m2.Groups[1].Value.Trim(),
                        Part2 = m2.Groups[2].Value.Trim(),
                        Part3 = m2.Groups[3].Value.Trim(),
                        MatchedFullValue = m2.Value
                    };
                }
            }
            return new UserAgentStringMatch()
            {
                IsSuccess = false,
            };
        }

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
        public static string? AnyStartsWith(this IEnumerable<string> collection, string str)
        {
            return collection.FirstOrDefault(x => x.StartsWith(str));
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
        /// <summary>
        /// <see cref="DescriptionAttribute"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryEnumParseFromDescriptionOrEnum<T>(this string? input, out T result) where T : struct, Enum
        {
            if (string.IsNullOrEmpty(input)) {
                result = default;
                return false; }
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var fieldInfo = typeof(T).GetField(value.ToString());
                var attribute = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                         .FirstOrDefault() as DescriptionAttribute;

                if (attribute != null && attribute.Description.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    result = value;
                    return true;
                }
            }

            // Eğer Description attribute'ü yoksa standart Enum.TryParse kullanılır.
            return Enum.TryParse(input, true, out result);
        }
    }
}
