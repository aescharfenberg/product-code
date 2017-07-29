﻿using System.Collections.Generic;
using System.Linq;
using Scharfenberg.ProductCode.Contracts;
using Scharfenberg.ProductCode.Specifications;

namespace Scharfenberg.ProductCode
{
    public static class ProductCodeSpecifications
    {
        /// <summary>
        /// Price Lookup Code (PLU).
        /// </summary>
        public static IProductCodeSpecification Plu => new PriceLookupSpecification();

        public static IProductCodeSpecification UpcE => new UniformCodeCouncilSpecification("UPC-E", 8);

        /// <summary>
        /// Universal Product Code (UPC-A/UCC-12).
        /// </summary>
        public static IProductCodeSpecification UpcA => new UniformCodeCouncilSpecification("UPC-A", 12, "UCC-12");

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        public static IProductCodeSpecification Ean => new UniformCodeCouncilSpecification("EAN", 13, "UCC-13");

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        public static IProductCodeSpecification Gtin => new UniformCodeCouncilSpecification("GTIN", 14, "UCC-14");

        /// <summary>
        /// Universal Commercial Code, Length 15 (UCC-15)
        /// </summary>
        public static IProductCodeSpecification Ucc15 => new UniformCodeCouncilSpecification("UCC-15", 15, "UCC-15");

        /// <summary>
        /// Universal Commercial Code, Length 16 (UCC-16)
        /// </summary>
        public static IProductCodeSpecification Ucc16 => new UniformCodeCouncilSpecification("UCC-16", 16, "UCC-16");

        /// <summary>
        /// Universal Commercial Code, Length 17 (UCC-17)
        /// </summary>
        public static IProductCodeSpecification Ucc17 => new UniformCodeCouncilSpecification("UCC-17", 17, "UCC-17");

        private static IEnumerable<IProductCodeSpecification> All => new[] {Plu, UpcE, UpcA, Ean, Gtin, Ucc15, Ucc16, Ucc17};

        internal static IEnumerable<IProductCode> Parse(string code)
        {
            var productCodes =
                from pct in All
                where pct.IsValid(code)
                select pct.Parse(code);

            return productCodes;
        }
    }
}