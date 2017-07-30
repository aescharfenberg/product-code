using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Tests.Unit.Models
{
    internal class ProductCode : IProductCode
    {
        public string Code { get; set; }

        public int CodeLength => Code.Length;

        public char? CheckDigit { get; set; }

        public IProductCodeType ProductCodeType { get; set; }
    }
}
