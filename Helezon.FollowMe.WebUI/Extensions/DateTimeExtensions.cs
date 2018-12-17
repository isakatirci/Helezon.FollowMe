using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Controllers
{
    public static class DateTimeExtensions
    {
        public static string ToLocalShortDateTurkish(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return string.Empty;
            return string.Format("{0:dd.MM.yyyy}", dateTime);
        }
        public static string ToLocalShortDateTurkish(this DateTime dateTime)
        {
            return string.Format("{0:dd.MM.yyyy}", dateTime);
        }
        public static DateTime? ToDateTime(this string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))            
                return (DateTime?)null;

            string[] formats = { "dd.MM.yyyy", "dd/MM/yyyy", "M/d/yyyy" };

            DateTime result;

            //todo: DateTimeStyles bunları araştırıp yazı kaleme al!
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out result))
                return result;

            return (DateTime?)null;
        }
    }
}