
using System;

namespace YS.CMS.Common.Utils
{
    public static class Extensions
    {
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
        public static bool HasValueNoSpace(this string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
        }
        public static string FormatDate(this DateTime date)
        {
            return string.Format("{0:dd/MM/yyyy}", date);
        }
    }
}
