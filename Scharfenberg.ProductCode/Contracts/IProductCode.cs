using System;
using System.Collections.Generic;
using System.Text;

namespace Scharfenberg.ProductCode.Contracts
{
    public interface IProductCode
    {
        string Code { get; }

        int CodeLength { get; }

        char CheckDigit { get; }

        string UccCode { get; }
    }
}
