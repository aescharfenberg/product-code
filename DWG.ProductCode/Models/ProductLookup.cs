using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class ProductLookup : ProductCode
    {
        public override IProductCodeType ProductCodeType => new ProductCodeType
        {
            Moniker = ProductCodeTypes.Plu.Moniker,
            CodeLength = Code?.Length ?? 0
        };
    }
}
