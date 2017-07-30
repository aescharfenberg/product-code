namespace Scharfenberg.ProductCode.Contracts
{
    public interface IProductCodeType
    {
        string Moniker { get; }

        int CodeLength { get; }
    }
}