using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class UniversalProductCodeTypeE : ProductCode
    {
        public override IProductCodeType ProductCodeType => new ProductCodeType
        {
            Moniker = "UPC-E",
            CodeLength = 8
        };
    }
}
