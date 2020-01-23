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
    }
}
