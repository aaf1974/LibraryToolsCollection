using System;
using System.ComponentModel;
using System.Globalization;

namespace ExtensionLibrary.StringExt
{
    public static class StringExtensionParcing
    {
        //https://extensionmethod.net/csharp/string/parse-t
        public static T LtcParse<T>(this string value)
        {
            T result = default(T);
            if (string.IsNullOrEmpty(value))
                return result;

            if (typeof(T) == typeof(DateTime))
                return (T)(object)value.LtcParseToDate();

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            result = (T)tc.ConvertFrom(value);
            return result;
        }

        //https://docs.microsoft.com/ru-ru/dotnet/standard/base-types/custom-date-and-time-format-strings
        static string[] datetTimeFormts = new[]
        {
            "yyyy-MM-dd HH:mm tt",
            "dd/MM/yyyy"
        };

        public static DateTime LtcParseToDate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return default(DateTime);

            var result = DateTime.ParseExact(value, datetTimeFormts, CultureInfo.InvariantCulture);
            return result;
        }

        public static DateTime LtcParseToDate(this string value, string format)
        {
            var result = DateTime.ParseExact(value, format, null);
            return result;
        }
    }
}
