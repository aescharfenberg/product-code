using System;
using System.Collections.Generic;
using System.Linq;
using Scharfenberg.ProductCode.Contracts;
using Scharfenberg.ProductCode.Models;
using Scharfenberg.ProductCode.Specifications;

namespace Scharfenberg.ProductCode
{
    public static class ProductCodeSpecifications
    {
        public static IProductCodeSpecification Plu => new PriceLookupTypeSpecification();

        public static IProductCodeSpecification UpcE => new ProductCodeSpecification("UPC-E", 8, null);

        public static IProductCodeSpecification Isbn9 => new ProductCodeSpecification("ISBN-9", 9, null);

        public static IProductCodeSpecification Isbn10 => new ProductCodeSpecification("ISBN-10", 9, null);

        /// <summary>
        /// Universal Product Code (UPC-A/UCC-12).
        /// </summary>
        public static IProductCodeSpecification UpcA => new ProductCodeSpecification("UPC-A", 12, null, "UCC-12");

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        public static IProductCodeSpecification Ean => new ProductCodeSpecification("EAN", 13, null);

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        public static IProductCodeSpecification Gtin => new ProductCodeSpecification("GTIN", 14, null);

        public static IProductCodeSpecification Ucc15 => new ProductCodeSpecification("UCC-15", 15, null);

        public static IProductCodeSpecification Ucc16 => new ProductCodeSpecification("UCC-16", 16, null);

        public static IProductCodeSpecification Ucc17 => new ProductCodeSpecification("UCC-17", 17, null);

        private static IEnumerable<IProductCodeSpecification> All => new[] {Plu, UpcE, Isbn9, Isbn10, UpcA, Ean, Gtin, Ucc15, Ucc16, Ucc17};

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