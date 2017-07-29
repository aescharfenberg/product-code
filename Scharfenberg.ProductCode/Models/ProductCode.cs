using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Models
{
    internal class ProductCode : IProductCode
    {
        public string Code { get; set; }

        public int CodeLength => ProductCodeType.CodeLength;

        public char? CheckDigit { get; set; }

        public string UccCode { get; set; }

        public IProductCodeSpecification ProductCodeType { get; set; }
    }
}