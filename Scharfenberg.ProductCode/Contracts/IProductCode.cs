namespace Scharfenberg.ProductCode.Contracts
{
    public interface IProductCode
    {
        string Code { get; }

        int CodeLength { get; }

        char? CheckDigit { get; }

        IProductCodeType ProductCodeType { get; }
    }
}