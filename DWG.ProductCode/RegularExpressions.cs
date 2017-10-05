﻿using System.Text.RegularExpressions;

namespace DWG.ProductCode
{
    internal static class RegularExpressions
    {
        internal static class PriceLookup
        {
            internal static readonly Regex InitialRegex = new Regex("^[0-9]{4,6}$");

            internal static readonly Regex Series3000Regex = new Regex("^(?<code>([0]|[9])?(3[0-9]{3}))$");

            internal static readonly Regex Series4000Regex = new Regex("^(?<code>([0]|[9])?(4[0-9]{3}))$");

            internal static readonly Regex Series83000Regex = new Regex("^(?<code>8(3[0-9]{3}))$");

            internal static readonly Regex Series84000Regex = new Regex("^(?<code>8(4[0-9]{3}))$");
        }
    }
}