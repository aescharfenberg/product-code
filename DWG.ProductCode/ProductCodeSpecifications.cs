using DWG.ProductCode.Contracts;
using DWG.ProductCode.Specifications;

namespace DWG.ProductCode
{
    internal static class ProductCodeSpecifications
    {
        /// <summary>
        /// Price Lookup (PLU).
        /// </summary>
        internal static IProductCodeSpecification Plu => new PriceLookupSpecification();

        /// <summary>
        /// Zero-Suppressed Universal Product Code (UPC-E).
        /// </summary>
        internal static IProductCodeSpecification UpcE => new ZeroCompressedUniversalProductCodeSpecification();

        /// <summary>
        /// Universal Product Code (UPC-A/UCC-12).
        /// </summary>
        internal static IProductCodeSpecification UpcA => new UniformCodeCouncilSpecification("UPC-A", 12, "UCC-12");

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        internal static IProductCodeSpecification Ean => new UniformCodeCouncilSpecification("EAN", 13, "UCC-13");

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        internal static IProductCodeSpecification Gtin => new UniformCodeCouncilSpecification("GTIN", 14, "UCC-14");

        /// <summary>
        /// Universal Code Council, Length 15 (UCC-15).
        /// </summary>
        internal static IProductCodeSpecification Ucc15 => new UniformCodeCouncilSpecification("UCC-15", 15, "UCC-15");

        /// <summary>
        /// Universal Code Council, Length 16 (UCC-16).
        /// </summary>
        internal static IProductCodeSpecification Ucc16 => new UniformCodeCouncilSpecification("UCC-16", 16, "UCC-16");

        /// <summary>
        /// Universal Code Council, Length 17 (UCC-17).
        /// </summary>
        internal static IProductCodeSpecification Ucc17 => new UniformCodeCouncilSpecification("UCC-17", 17, "UCC-17");
    }
}
