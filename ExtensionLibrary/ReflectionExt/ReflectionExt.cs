using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExtensionLibrary.ReflectionExt
{

	public static class ReflectionExt
    {
		//https://extensionmethod.net/csharp/object/clone-t

		/// <summary>
		/// Makes a copy from the object.
		/// Doesn't copy the reference memory, only data.
		/// </summary>
		/// <typeparam name="T">Type of the return object.</typeparam>
		/// <param name="item">Object to be copied.</param>
		/// <returns>Returns the copied object.</returns>
		public static T LtcClone<T>(this object item)
		{
			if (item != null)
			{
				BinaryFormatter formatter = new BinaryFormatter();
				MemoryStream stream = new MemoryStream();

				formatter.Serialize(stream, item);
				stream.Seek(0, SeekOrigin.Begin);

				T result = (T)formatter.Deserialize(stream);

				stream.Close();

				return result;
			}
			else
				return default(T);
		}


		/// <summary>
		/// https://stackoverflow.com/questions/18680083/how-to-add-a-datepicker-to-datagridtextcolumn-in-wpf
		/// </summary>
		/// <param name="propertyType"></param>
		/// <param name="desiredType"></param>
		/// <returns></returns>
		public static bool IsTypeOrNullableOfType(this Type propertyType, Type desiredType)
		{
			return (propertyType == desiredType || Nullable.GetUnderlyingType(propertyType) == desiredType);
		}

		public static bool LtcIsNullableOfValueType(this Type propertyType)
		{
			return (propertyType.IsValueType ||
					(Nullable.GetUnderlyingType(propertyType) != null &&
					 Nullable.GetUnderlyingType(propertyType).IsValueType));
		}


		[Obsolete(message:"not correct", error: false)]
		public static bool LtcIsNullable(this Type type)
		{
			if (Nullable.GetUnderlyingType(type) != null)
				return true;

			return false;
		}


		//TODO: need to implement
		//https://github.com/AnthonyGiretti/aspnetcore-multitenant-injectiondependency/blob/master/Plugins.Tools/Extensions/TypeExtensions.cs
		public static IEnumerable<Type> FilterByInterface(this IEnumerable<Type> pluggableItems, Type interfaceType)
		{
			throw new NotImplementedException();
		}
	}
}
