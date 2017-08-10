using System;

namespace DWG.Extensions
{
    public static class StringExtensions
    {
        public static string Right(this string value, int count)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Length < count)
                throw new ArgumentOutOfRangeException(nameof(count));

            var right = value.Substring(value.Length - 1 - count, count);

            return right;
        }
    }
}
