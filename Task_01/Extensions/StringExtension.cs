using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_01.Extensions
{
    public static class StringExtension
    {
        public static byte[] GetDigits(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var digitsMatch = new Regex(@"[0-9]");
            var result = digitsMatch.Matches(text).Select(m => byte.Parse(m.Value)).ToArray();
            return result;
        }
    }
}
