using System;
using System.Collections.Generic;
using System.Text;

namespace DWG.ProductCode.Contracts
{
    public interface IUpcAConverter
    {
        IProductCode ToUpcE();

        IProductCode ToEan();
    }
}
