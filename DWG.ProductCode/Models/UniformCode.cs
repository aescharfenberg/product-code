using DWG.ProductCode.Contracts;

namespace DWG.ProductCode.Models
{
    internal class UniformCode : ProductCode
    {
        private readonly string _moniker;

        public UniformCode(string moniker)
        {
            _moniker = moniker;
        }

        protected UniformCode()
        {
        }

        public override IProductCodeType ProductCodeType => new ProductCodeType
        {
            Moniker = _moniker,
            CodeLength = Code?.Length ?? 0
        };
    }
}
