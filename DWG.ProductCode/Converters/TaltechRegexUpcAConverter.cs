using System;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Models;

namespace DWG.ProductCode.Converters
{
    internal class TaltechRegexUpcAConverter : IUpcAConverter
    {
        public UniversalProductCodeTypeE Source { get; }

        public TaltechRegexUpcAConverter(UniversalProductCodeTypeE source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public IProductCode ToUpcE()
        {
            throw new NotImplementedException();
        }

        public IProductCode ToEan()
        {
            throw new NotImplementedException();
        }
    }
}
