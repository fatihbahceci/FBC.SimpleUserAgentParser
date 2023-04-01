using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace FBC.SimpleUserAgentParser
{
    internal static class H
    {
        public static string[] NOT_SET_ARGS = { "-", "Unknown" };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>value is not null, not empty and not one of <see cref="NOT_SET_ARGS"/> </returns>
        public static bool IsStringPropertySet(this string s)
        {
            return !string.IsNullOrEmpty(s) && !NOT_SET_ARGS.Any(x => s.ToLower() == x.ToLower());
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
        /// Case Insensitive
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool StartsWithOneOfTheseCI(this string str, params string[] args)
        {
            return StartsWithOneOfThese(str, caseInsensitive: true, args);
        }
        public static string Windowize(this string regularString)
        {
            if (regularString.Contains("\n") && !regularString.Contains("\r"))
            {
                regularString = regularString.Replace("\n", "\r\n");
            }
            return regularString;
        }
        private static readonly string[] lineSplitter = { "\r\n", "\r", "\n" };

        public static string[] SplitWith(this string s, string splitter, bool trimLinesToo, StringSplitOptions opt = StringSplitOptions.None)
        {
            var r = s.Split(new string[] { splitter }, opt);
            if (trimLinesToo)
                r = r.Select(x => x.Trim()).ToArray();
            return r;
        }
        public static string[] SplitWith(this string s, char splitter, bool trimLinesToo, StringSplitOptions opt = StringSplitOptions.None)
        {
            var r = s.Split(new char[] { splitter }, opt);
            if (trimLinesToo)
                r = r.Select(x => x.Trim()).ToArray();
            return r;
        }

        public static string GetBetweenTags(this string asmContent, string beginTag, string endTag)
        {
            var startIndex = asmContent.IndexOf(beginTag);
            if (startIndex >= 0)
            {
                var endIndex = asmContent.IndexOf(endTag, startIndex);
                if (endIndex > startIndex)
                {
                    return asmContent.Substring(startIndex, (endTag.Length + endIndex) - startIndex);
                }
            }
            return String.Empty;
        }

        public static string[] SplitLines(this string s, bool trimLinesToo, StringSplitOptions opt = StringSplitOptions.None, bool windowize = false)
        {
            if (windowize)
                s = s.Windowize();
            var r = s.Split(lineSplitter, opt);
            if (trimLinesToo)
                r = r.Select(x => x.Trim()).ToArray();
            return r;
        }

        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            try
            {
                var e = Enum.GetValues(typeof(T))
                    .Cast<T>()
                    .Where(x => x?.GetDescription() == description)
                    .First();
                if (e != null)
                {
                    return e;
                }
                try
                {
                    return (T)Enum.Parse(typeof(T), description);
                }
                catch
                {

                }
            }
            catch
            {

            }
            //foreach (var field in typeof(T).GetFields())
            //{
            //    if (Attribute.GetCustomAttribute(field,
            //    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            //    {
            //        if (attribute.Description == description)
            //            return (T)field.GetValue(null);
            //    }
            //    else
            //    {
            //        if (field.Name == description)
            //            return (T)field.GetValue(null);
            //    }
            //}

            throw new ArgumentException("Not found.", description ?? "<null>");
            // Or return default(T);
        }

        internal static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions() {WriteIndented = true });
            //return JsonConvert.SerializeObject(obj, Formatting.Indented, new StringEnumConverter());
        }
    }
}
