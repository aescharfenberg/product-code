namespace Scharfenberg.ProductCode.Contracts
{
    public interface IProductCodeType
    {
        string Moniker { get; }

        int CodeLength { get; }

        IProductCode Parse(string code);

        bool TryParse(string code, out IProductCode productCode);

        bool IsValid(string code);
    }
}