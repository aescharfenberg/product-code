namespace DWG.ProductCode.Contracts
{
    public interface IProductCodeSpecification
    {
        string Moniker { get; }

        IProductCode Parse(string code);

        int MaxCodeLength { get;  }

        bool TryParse(string code, out IProductCode productCode);

        bool IsValid(string code);
    }
}