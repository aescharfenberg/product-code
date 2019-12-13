using System;
using System.Collections.Generic;
using System.Linq;
using DWG.ProductCode.Contracts;
using static DWG.ProductCode.ProductCodeSpecifications;

namespace DWG.ProductCode
{
    public static class Interpolate
    {
        /// <summary>
        /// All supported specifications.
        /// </summary>
        internal static IEnumerable<IProductCodeSpecification> All => new[] { Plu, UpcE, UpcA, Ean, Gtin, Ucc15, Ucc16, Ucc17 };

        /// <summary>
        /// Interpolates a supported product s from the string provided.
        /// </summary>
        /// <param name="s">The string to interpolate.</param>
        /// <returns>A product code; or null if the string provided does not interpolate to a supported product code.</returns>
        public static IProductCode FromString(string s)
        {
            var productCodes =
                from pct in All
                where pct.IsValid(s)
                select pct.Parse(s);

            var productCode = productCodes.FirstOrDefault();
            return productCode;
        }
    }
}
