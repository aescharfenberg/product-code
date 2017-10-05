using System;
using System.Text.RegularExpressions;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Models;

namespace DWG.ProductCode.Specifications
{
    internal class PriceLookupSpecification : IProductCodeSpecification
    {
        public string Moniker => "PLU";

        public int MaxCodeLength => 5;

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

        private Models.ProductCode BuildProductCode(Capture match)
        {
            var code = match.Value;

            var productCode =
                new Models.ProductCode
                {
                    Code = code,
                    CheckDigit = null,
                    ProductCodeType = new ProductCodeType
                    {
                        Moniker = Moniker,
                        CodeLength = code.Length
                    }
                };

            return productCode;
        }

        private static Match Match(string code)
        {
            if (!RegularExpressions.PriceLookup.InitialRegex.IsMatch(code))
                return null;

            // ReSharper disable once JoinDeclarationAndInitializer
            Match match;

            match = RegularExpressions.PriceLookup.Series3000Regex.Match(code);
            if (match.Success)
                return match;

            match = RegularExpressions.PriceLookup.Series4000Regex.Match(code);
            if (match.Success)
                return match;

            match = RegularExpressions.PriceLookup.Series83000Regex.Match(code);
            if (match.Success)
                return match;

            match = RegularExpressions.PriceLookup.Series84000Regex.Match(code);
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (match.Success)
                return match;

            return null;
        }


    }
}
