using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Tests.Unit.Models
{
    internal class ProductCodeType : IProductCodeType
    {
        public string Moniker { get; set; }

        public int CodeLength { get; set; }
    }
}