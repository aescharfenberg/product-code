﻿using System.Linq;
using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode
{
    public static class ProductCodes
    {
        public static IProductCode Parse(string code)
        {
            var productCode = ProductCodeSpecifications.Parse(code).Single();
            return productCode;
        }
    }
}