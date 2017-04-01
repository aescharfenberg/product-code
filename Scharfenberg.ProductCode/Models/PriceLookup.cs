using System;
using System.Collections.Generic;
using System.Text;
using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Models
{
    public class PriceLookupType : IProductCodeSpecification
    {
        public string Moniker
        {
            get { return "PLU"; }
        }

        public int CodeLength { get; }

        public IProductCode Parse(string code)
        {
            throw new NotImplementedException();
        }

        public bool TryParse(string code, out IProductCode productCode)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string code)
        {
            throw new NotImplementedException();
        }
    }
}
