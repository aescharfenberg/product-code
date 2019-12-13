using DWG.ProductCode.Contracts;
using DWG.ProductCode.Converters;
using DWG.ProductCode.Models;

namespace DWG.ProductCode
{
    public static class Convert
    {
        public static IUpcEConverter FromUpcE(string s)
        {
            var specification = ProductCodeSpecifications.UpcE;
            var productCode = specification.Parse(s) as UniversalProductCodeTypeE;

            var converter = new TaltechRegexUpcEConverter(productCode);
            return converter;
        }
    }
}
