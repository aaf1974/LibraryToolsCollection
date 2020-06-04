using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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


        public static bool LtcIsDate(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                DateTime dt;
                return (DateTime.TryParse(input, out dt));
            }
            else
            {
                return false;
            }
        }

        public static bool LtcIsEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
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
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string result = input.First().ToString().ToUpper() + input.Substring(1);

            return result;

            //https://stackoverflow.com/questions/11959380/how-to-get-the-descriptionattribute-value-from-an-enum-member
            //"FooBar" -> "Foo Bar"
            result = Regex.Replace(result, @"([a-z])([A-Z])", "$1 $2");

            //"Foo123" -> "Foo 123"
            result = Regex.Replace(result, @"([A-Za-z])([0-9])", "$1 $2");

            //"123Foo" -> "123 Foo"
            result = Regex.Replace(result, @"([0-9])([A-Za-z])", "$1 $2");

            //"FOOBar" -> "FOO Bar"
            result = Regex.Replace(result, @"(?<!^)(?<! )([A-Z][a-z])", " $1");

            return result;

            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }


        //https://extensionmethod.net/csharp/string/tocamelcase
        [Obsolete("Не протестированно/Not testing", false)]
        public static string LtcToCamelCase2(this string the_string)
        {
            if (the_string == null || the_string.Length < 2)
                return the_string;

            string[] words = the_string.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
            }

            return result;
        }


        //https://extensionmethod.net/csharp/string/string-extensions
        /// <summary>
        /// Checks string object's value to array of string values
        /// </summary>        
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool LtcIn(this string value, params string[] stringValues)
        {
            return stringValues.Any(x => x == value);
        }


        public static string LtcUpperFirst(this string theString)
        {
            if (string.IsNullOrEmpty(theString))
            {
                return theString;
            }

            char[] theChars = theString.ToCharArray();
            theChars[0] = char.ToUpper(theChars[0]);

            return new string(theChars);
        }
    }
}
