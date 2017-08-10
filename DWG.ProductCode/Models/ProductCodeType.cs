using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class ProductCodeType : IProductCodeType
    {
        public string Moniker { get; set; }

        public int CodeLength { get; set; }
    }
}
