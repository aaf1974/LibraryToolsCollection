using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ExtensionLibrary.StringExt
{
    public static class StringExtension
    {
        public static string LtcTrim(this string value)
        {
            if (value == null)
                return string.Empty;

            return value.Trim();
        }

        //https://www.codeproject.com/Articles/31050/String-Extension-Collection-for-C

        public static bool LtcIsNumberOnly(this string s)
        {
            s = s.Trim();
            if (s.Length == 0)
                return false;
            bool floatpoint = s.Contains('.') || s.Contains(',');

            return s.LtcIsNumberOnly(floatpoint);
        }

        public static bool LtcIsNumberOnly(this string s, bool floatpoint)
        {
            s = s.Trim();
            if (s.Length == 0)
                return false;
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    if (floatpoint && (c == '.' || c == ','))
                        continue;
                    return false;
                }
            }
            return true;
        }

        //https://habr.com/ru/post/24765/
        public static string LtcList2String(this IList list)
        {
            return list.LtcList2String(",");

            //Original impl:
            //StringBuilder result = new StringBuilder("");

            //if (list.Count > 0)
            //{
            //    result.Append(list[0].ToString());
            //    for (int i = 1; i < list.Count; i++)
            //        result.AppendFormat(", {0}", list[i].ToString());
            //}
            //return result.ToString();
        }

        public static string LtcList2String(this IList list, string separator)
        {
            StringBuilder result = new StringBuilder("");

            if (list.Count > 0)
            {
                result.Append(list[0].ToString());
                for (int i = 1; i < list.Count; i++)
                    result.Append($"{separator} {list[i].ToString()}");
            }
            return result.ToString();
        }

        public static string Ltc2CamelCase(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
