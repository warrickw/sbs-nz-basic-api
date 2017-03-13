using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2
{
    public static class SbsCurrencyUtilities
    {
        /// <summary>
        /// Parse the monetary values returned by the SBS api
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal Parse(string stringValue)
        {
            bool isPositive = stringValue.Contains("+");

            string sanitized = stringValue.Replace(",", "")
                .Replace("$", "")
                .Replace("+", "")
                .Replace("-", "");

            decimal value = decimal.Parse(sanitized);

            // If the value isn't posible, multiply it by -1
            if (!isPositive)
                value *= -1;

            return value;
        }
    }
}
