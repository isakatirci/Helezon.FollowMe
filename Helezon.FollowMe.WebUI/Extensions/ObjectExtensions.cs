using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace FollowMe.Web.Controllers
{
    public static class ObjectExtensions
    {
        public static string ToBooleanString(this bool? boolean)
        {
            return boolean.HasValue && boolean.Value ? bool.TrueString : bool.FalseString;
        }

        public static bool Not(this bool value)
        {
            return !value;
        }

        public static string SafeTrim(this string value)
        {
            return value.IsNullOrWhiteSpace().Not() ? value.Trim() : string.Empty;
        }
        public static bool EqualsTurkishCulture(this string value, string other)
        {
            return string.Compare(value, other, new CultureInfo("tr-TR"), CompareOptions.IgnoreCase) == 0;
        }

        public static string ToIntegerString(this int? integer)
        {
            return integer.HasValue ? integer.ToString() : string.Empty;
        }
        public static T DeepClone<T>(this T obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            return value == null || !value.Any();
        }


    }
}