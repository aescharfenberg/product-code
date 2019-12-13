using System;
using System.Collections.Generic;
using DWG.ProductCode.Contracts;

namespace DWG.ProductCode
{
    [Obsolete("This class will be removed in v2.0. Use DWG.ProductCode.Interpolate instead.")]
    public static class ProductCodeTypes
    {
        /// <summary>
        /// Price Lookup (PLU).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification Plu => ProductCodeSpecifications.Plu;

        /// <summary>
        /// Zero-Suppressed Universal Product Code (UPC-E).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification UpcE => ProductCodeSpecifications.UpcE;

        /// <summary>
        /// Universal Product Code (UPC-A/UCC-12).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification UpcA => ProductCodeSpecifications.UpcA;

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification Ean => ProductCodeSpecifications.Ean;

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification Gtin => ProductCodeSpecifications.Gtin;

        /// <summary>
        /// Universal Code Council, Length 15 (UCC-15).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification Ucc15 => ProductCodeSpecifications.Ucc15;

        /// <summary>
        /// Universal Code Council, Length 16 (UCC-16).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification Ucc16 => ProductCodeSpecifications.Ucc16;

        /// <summary>
        /// Universal Code Council, Length 17 (UCC-17).
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IProductCodeSpecification Ucc17 => ProductCodeSpecifications.Ucc17;

        /// <summary>
        /// All supported specifications.
        /// </summary>
        [Obsolete("This property will be removed in v2.0.")]
        public static IEnumerable<IProductCodeSpecification> All => ProductCode.Interpolate.All;

        [Obsolete("This method will be removed in v2.0. Use DWG.ProductCode.Interpolate.FromString(code) instead.")]
        public static IProductCode Interpolate(string code)
        {
            return ProductCode.Interpolate.FromString(code);
        }
    }
}