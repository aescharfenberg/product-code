using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Models
{
    internal class ProductCodeType : IProductCodeType
    {
        public string Moniker { get; set; }

        public int CodeLength { get; }

        public IProductCode Parse(string code)
        {
            throw new System.NotImplementedException();
        }

        public bool TryParse(string code, out IProductCode productCode)
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}