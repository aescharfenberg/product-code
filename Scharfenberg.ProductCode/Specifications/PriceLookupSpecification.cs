using System;
using System.Linq;
using System.Text.RegularExpressions;
using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Specifications
{
    internal class PriceLookupTypeSpecification : IProductCodeSpecification
    {
        public string Moniker => "PLU";

        public int CodeLength => 6;

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
            return match.Success;
        }

        private Models.ProductCode BuildProductCode(Match match)
        {
            var code = match.Groups["code"].Value;

            var productCode =
                new Models.ProductCode
                {
                    Code = code,
                    CheckDigit = Calculations.CalculateCheckDigit(code),
                    ProductCodeType = this
                };

            return productCode;
        }

        private static Match Match(string code)
        {
            if (!RegularExpressions.PriceLookup.InitialRegex.IsMatch(code))
                return null;

            Match match;

            match = RegularExpressions.PriceLookup.Series3000Regex.Match(code);
            if (match.Success && IsCheckDigitValid(match))
                return match;

            match = RegularExpressions.PriceLookup.Series4000Regex.Match(code);
            if (match.Success && IsCheckDigitValid(match))
                return match;

            match = RegularExpressions.PriceLookup.Series83000Regex.Match(code);
            if (match.Success && IsCheckDigitValid(match))
                return match;

            match = RegularExpressions.PriceLookup.Series84000Regex.Match(code);
            if (match.Success && IsCheckDigitValid(match))
                return match;

            return null;
        }

        private static bool IsCheckDigitValid(Match match)
        {
            var checkDigitGroup = match.Groups["checkDigit"];
            if (!checkDigitGroup.Success)
                return true;

            var code = match.Groups["code"].Value;
            var checkDigit = checkDigitGroup.Value.ToCharArray().Single();
            var calculatedCheckDigit = Calculations.CalculateCheckDigit(code);

            return checkDigit == calculatedCheckDigit;
        }
    }
}
