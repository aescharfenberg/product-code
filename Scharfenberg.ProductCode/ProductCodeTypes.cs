using System.Collections.Generic;
using System.Linq;
using Scharfenberg.ProductCode.Contracts;
using Scharfenberg.ProductCode.Specifications;

namespace Scharfenberg.ProductCode
{
    public static class ProductCodeTypes
    {
        /// <summary>
        /// Price Lookup (PLU).
        /// </summary>
        public static IProductCodeSpecification Plu => new PriceLookupSpecification();

        /// <summary>
        /// Universal Product Code (UPC-A/UCC-12).
        /// </summary>
        public static IProductCodeSpecification UpcA => new UniformCodeCouncilSpecification("UPC-A", 12, "UCC-12");

        /// <summary>
        /// Zero-Suppressed Universal Product Code (UPC-E).
        /// </summary>
        public static IProductCodeSpecification UpcE => new UniformCodeCouncilSpecification("UPC-E", 8);

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        public static IProductCodeSpecification Ean => new UniformCodeCouncilSpecification("EAN", 13, "UCC-13");

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        public static IProductCodeSpecification Gtin => new UniformCodeCouncilSpecification("GTIN", 14, "UCC-14");

        /// <summary>
        /// Universal Code Council, Length 15 (UCC-15).
        /// </summary>
        public static IProductCodeSpecification Ucc15 => new UniformCodeCouncilSpecification("UCC-15", 15, "UCC-15");

		/// <summary>
		/// Universal Code Council, Length 16 (UCC-16).
		/// </summary>
		public static IProductCodeSpecification Ucc16 => new UniformCodeCouncilSpecification("UCC-16", 16, "UCC-16");

		/// <summary>
		/// Universal Code Council, Length 17 (UCC-17).
		/// </summary>
		public static IProductCodeSpecification Ucc17 => new UniformCodeCouncilSpecification("UCC-17", 17, "UCC-17");

        public static IEnumerable<IProductCodeSpecification> All => new[] {Plu, UpcE, UpcA, Ean, Gtin, Ucc15, Ucc16, Ucc17};

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