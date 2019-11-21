namespace DWG.ProductCode.Contracts
{
    public interface IUpcEConverter
    {
        IProductCode ToUpcA();

        IProductCode ToEan();
    }
}
