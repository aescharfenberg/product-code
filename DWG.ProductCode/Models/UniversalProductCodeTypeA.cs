using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class UniversalProductCodeTypeA : UniformCode
    {
        public override IProductCodeType ProductCodeType => new ProductCodeType
        {
            Moniker = "UPC-A",
            CodeLength = 12
        };
    }
}
