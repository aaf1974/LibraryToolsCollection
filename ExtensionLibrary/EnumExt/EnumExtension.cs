using EnumsNET;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionLibrary.EnumExt
{
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

        //public static string LtcGetDescription<T>(this T val, EnumFormat format = EnumFormat.Description)
        //    where T: struct, Enum
        //{
        //    return val.AsString(format) ?? string.Empty;
        //}

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
        
        mathaFaca;
    } 
    
}
