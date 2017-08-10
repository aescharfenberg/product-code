using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class ProductCode : IProductCode
    {
        public string Code { get; set; }

        public int CodeLength => ProductCodeType.CodeLength;

        public char? CheckDigit { get; set; }

        public IProductCodeType ProductCodeType { get; set; }
    }
}