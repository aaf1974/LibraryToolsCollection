using System;
using System.Collections.Generic;
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
    }
}
