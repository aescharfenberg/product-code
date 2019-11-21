using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal abstract class ProductCode : IProductCode
    {
        public string Code { get; set; }

        public int CodeLength => ProductCodeType.CodeLength;

        public char? CheckDigit { get; set; }

        public abstract IProductCodeType ProductCodeType { get; }

        public override string ToString()
        {
            return $"{ProductCodeType?.Moniker} {Code} (Length = {CodeLength}, CheckDigit = {CheckDigit})";
        }
    }
}