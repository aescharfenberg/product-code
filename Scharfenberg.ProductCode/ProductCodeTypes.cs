using System;
using System.Collections.Generic;
using System.Linq;
using Scharfenberg.ProductCode.Contracts;
using Scharfenberg.ProductCode.Models;

namespace Scharfenberg.ProductCode
{
    public static class ProductCodeTypes
    {
        public static IProductCodeType Plu => BuildPluProductCodeType();

        /// <summary>
        /// Universal Product Code (UPC/UCC-12).
        /// </summary>
        public static IProductCodeType Upc => BuildUpcProductCodeType();

        /// <summary>
        /// European Article Number (EAN/UCC-13).
        /// </summary>
        public static IProductCodeType Ean => BuildEanProductCodeType();

        /// <summary>
        /// Global Trade Item Number (GTIN/UCC-14).
        /// </summary>
        public static IProductCodeType Gtin => BuildGtinProductCodeType();

        public static IProductCodeType Ucc15 => BuildUcc15ProductCodeType();

        public static IProductCodeType Ucc16 => BuildUcc16ProductCodeType();

        public static IProductCodeType Ucc17 => BuildUcc17ProductCodeType();

        private static IEnumerable<IProductCodeType> All => new[] {Plu, Upc, Ean, Gtin, Ucc15, Ucc16, Ucc17};

        internal static IEnumerable<IProductCode> Parse(string code)
        {
            var productCodes =
                from pct in All
                where pct.IsValid(code)
                select pct.Parse(code);

            return productCodes;
        }

        public static IEnumerator<IProductCodeType> GetEnumerator()
        {
            foreach (var productCodeType in All)
                yield return productCodeType;
        }

        private static IProductCodeType BuildPluProductCodeType()
        {
            var pluProductCodeType =
                new ProductCodeType
                {
                    
                };

            return pluProductCodeType;
        }

        private static IProductCodeType BuildUpcProductCodeType()
        {
            var upcProductCodeType =
                new ProductCodeType
                {

                };

            return upcProductCodeType;
        }

        private static IProductCodeType BuildEanProductCodeType()
        {
            var eanProductCodeType =
                new ProductCodeType
                {

                };

            return eanProductCodeType;
        }

        private static IProductCodeType BuildGtinProductCodeType()
        {
            var gtinProductCodeType =
                new ProductCodeType
                {

                };

            return gtinProductCodeType;
        }

        private static IProductCodeType BuildUcc15ProductCodeType()
        {
            var ucc15ProductCodeType =
                new ProductCodeType
                {

                };

            return ucc15ProductCodeType;
        }

        private static IProductCodeType BuildUcc16ProductCodeType()
        {
            var ucc16ProductCodeType =
                new ProductCodeType
                {

                };

            return ucc16ProductCodeType;
        }

        private static IProductCodeType BuildUcc17ProductCodeType()
        {
            var ucc17ProductCodeType =
                new ProductCodeType
                {

                };

            return ucc17ProductCodeType;
        }
    }
}