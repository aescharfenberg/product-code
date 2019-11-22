using System;
using System.Collections.Generic;
using System.Linq;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Specifications;

namespace DWG.ProductCode
{
    [Obsolete]
    public static class ProductCodeTypes
    {
        /// <summary>
        /// Price Lookup (PLU).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification Plu => new PriceLookupSpecification();

        /// <summary>
        /// Zero-Suppressed Universal Product Code (UPC-E).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification UpcE => new ZeroCompressedUniversalProductCodeSpecification();

        /// <summary>
        /// Universal Product Code (UPC-A/UCC-12).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification UpcA => new UniformCodeCouncilSpecification("UPC-A", codeLength: 12, "UCC-12");

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification Ean => new UniformCodeCouncilSpecification("EAN", codeLength: 13, "UCC-13");

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification Gtin => new UniformCodeCouncilSpecification("GTIN", codeLength: 14, "UCC-14");

        /// <summary>
        /// Universal Code Council, Length 15 (UCC-15).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification Ucc15 => new UniformCodeCouncilSpecification("UCC-15", codeLength: 15, "UCC-15");

        /// <summary>
        /// Universal Code Council, Length 16 (UCC-16).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification Ucc16 => new UniformCodeCouncilSpecification("UCC-16", codeLength: 16, "UCC-16");

        /// <summary>
        /// Universal Code Council, Length 17 (UCC-17).
        /// </summary>
        [Obsolete]
        public static IProductCodeSpecification Ucc17 => new UniformCodeCouncilSpecification("UCC-17", codeLength: 17, "UCC-17");

        /// <summary>
        /// All supported specifications.
        /// </summary>
        [Obsolete]
        public static IEnumerable<IProductCodeSpecification> All => new[] {Plu, UpcE, UpcA, Ean, Gtin, Ucc15, Ucc16, Ucc17};

        [Obsolete]
        public static IProductCode Interpolate(string code)
        {
            var productCodes =
                from pct in All
                where pct.IsValid(code)
                select pct.Parse(code);

            var productCode = productCodes.FirstOrDefault();
            return productCode;
        }
    }
}