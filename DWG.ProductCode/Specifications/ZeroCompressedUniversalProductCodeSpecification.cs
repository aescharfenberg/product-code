using System;
using System.Linq;
using System.Text.RegularExpressions;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Models;

namespace DWG.ProductCode.Specifications
{
    internal class ZeroCompressedUniversalProductCodeSpecification : IProductCodeSpecification
    {
        public string Moniker => "UPC-E";

        public int MinCodeLength => 6;

        public int MaxCodeLength => 8;

        private Regex Regex => new Regex($"^0?(?<code>[0-9]{{{MinCodeLength}}})(?<checkDigit>[0-9])?$");

        public IProductCode Parse(string code)
        {
            var match = Match(code);
            if (match == null || !match.Success)
                throw new FormatException();

            var productCode = BuildProductCode(match);
            return productCode;
        }

        public bool TryParse(string code, out IProductCode productCode)
        {
            productCode = null;

            var match = Match(code);
            if (match == null || !match.Success)
                return false;

            productCode = BuildProductCode(match);

            return true;
        }

        public bool IsValid(string code)
        {
            var match = Match(code);
            return match != null && match.Success;
        }

        private Models.ProductCode BuildProductCode(Match match)
        {
            var codeGroup = match.Groups["code"];
            var code = codeGroup.Value;
            var calculatedCheckDigit = Converters.ConvertToUpcA(code).ToCharArray().Last();

            var productCode =
                new Models.ProductCode
                {
                    Code = $"0{code}{calculatedCheckDigit}",
                    CheckDigit = calculatedCheckDigit,
                    ProductCodeType = new ProductCodeType
                    {
                        Moniker = Moniker,
                        CodeLength = MaxCodeLength
                    }
                };

            return productCode;
        }

        private Match Match(string code)
        {
            var match = Regex.Match(code);

            if (match.Success && IsCheckDigitValid(match))
                return match;

            return null;
        }

        private static bool IsCheckDigitValid(Match match)
        {
            var codeGroup = match.Groups["code"];
            var code = codeGroup.Value;

            var checkDigitGroup = match.Groups["checkDigit"];
            if (!checkDigitGroup.Success) // Optional
                return true;
            var checkDigit = checkDigitGroup.Value.ToCharArray().Single();

            var calculatedCheckDigit = Converters.ConvertToUpcA(code).ToCharArray().Last();
            return checkDigit == calculatedCheckDigit;
        }
    }
}