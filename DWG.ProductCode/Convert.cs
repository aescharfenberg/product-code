using System.Text.RegularExpressions;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Converters;
using DWG.ProductCode.Models;

namespace DWG.ProductCode
{
    public static class Convert
    {
        public static IUpcEConverter FromUpcE(string code)
        {
            var specification = ProductCodeTypes.UpcE;
            var productCode = specification.Parse(code) as UniversalProductCodeTypeE;

            var converter = new TaltechRegexUpcEConverter(productCode);
            return converter;
        }
    }
}
