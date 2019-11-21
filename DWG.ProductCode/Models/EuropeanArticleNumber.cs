using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class EuropeanArticleNumber : ProductCode
    {
        public override IProductCodeType ProductCodeType => new ProductCodeType
        {
            Moniker = "EAN",
            CodeLength = 13
        };
    }
}
