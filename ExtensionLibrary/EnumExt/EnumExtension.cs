using EnumsNET;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionLibrary.EnumExt
{
    //https://extensionmethod.net/csharp/enum
    public static class EnumExtension
    {

        #region Get collection
        public static IEnumerable<TEnum> LtcValues<TEnum>(this TEnum enumElement)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return LtcValues<TEnum>();
        }

        public static IEnumerable<TEnum> LtcValues<TEnum>()
                where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);

            // Optional runtime check for completeness    
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Not enum as argument");
            }

            return LtcGetEnumCollection<TEnum>();
        }


        public static IEnumerable<TEnum> LtcGetEnumCollection<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
        #endregion


        #region Description
        public static string LtcGetDescription<TEnum>(this TEnum val, EnumFormat format = EnumFormat.Description, EnumFormat format2 = EnumFormat.DisplayName)
            where TEnum : struct, Enum
        {
            return val.AsString(format, format2) ?? string.Empty;
        }


        /// <summary>
        /// Returned dictionary (enumElement, enumDescription/DisplayName)
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Dictionary<TEnum, string> LtcGetEnumDictionary<TEnum>(this TEnum val)
           where TEnum : struct, Enum
        {
            Dictionary<TEnum, string> result = LtcGetEnumCollection<TEnum>()
                .ToList()
                .ToDictionary(x => x, x => x.LtcGetDescription(EnumFormat.Description, EnumFormat.DisplayName));

            return result;
        }

        public static bool LtcHasDescription<TEnum>(this TEnum someEnum)
            where TEnum : struct, Enum
        {
            return !string.IsNullOrWhiteSpace(someEnum.LtcGetDescription());
        } 
        #endregion

        public static bool LtcIsSet(this Enum input, Enum matchTo)
        {
            return (Convert.ToUInt32(input) & Convert.ToUInt32(matchTo)) != 0;
        }
    }


    /// <summary> Enum Extension Methods </summary>
    /// <typeparam name="T"> type of Enum </typeparam>
    public class Enum<T> where T : struct, Enum
    {
        public static int Count
        {
            get
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("T must be an enumerated type");

                return Enum.GetNames(typeof(T)).Length;
            }
        }

        public static T FindByString(string valueString)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return (T)Enum.Parse(typeof(T), valueString);
        }

        public static T FindByString(string valueString, T defaultValue)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            T res;
            var done = Enum.TryParse(valueString, true, out res);

            return done ? res : defaultValue;
        }

        private static bool IsEnum
        {
            get
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("T must be an enumerated type");

                return true;
            }
        }
    }
}
