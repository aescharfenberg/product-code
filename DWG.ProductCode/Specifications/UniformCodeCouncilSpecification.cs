using System;
using System.Linq;
using System.Text.RegularExpressions;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Models;

namespace DWG.ProductCode.Specifications
{
    internal class UniformCodeCouncilSpecification : IProductCodeSpecification
    {        
        public string Moniker { get; }

        public int MaxCodeLength { get; }

        public string UccName { get; }

        private Regex Regex { get; }

        internal UniformCodeCouncilSpecification(string moniker, int codeLength, string uccName = null)
        {
            Moniker = moniker;
            MaxCodeLength = codeLength;
            UccName = uccName;
            Regex = new Regex($"^[0-9]{{{codeLength - 1}}}(?<checkDigit>[0-9])$");
        }

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

        private UniformCode BuildProductCode(Match match)
        {
            var productCode = new UniformCode(Moniker)
            {
                Code = match.Value,
                CheckDigit = match.Groups["checkDigit"].Value.ToCharArray().Single()
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

        private bool IsCheckDigitValid(Match match)
        {
            var checkDigitGroup = match.Groups["checkDigit"];
            var checkDigit = checkDigitGroup.Value.ToCharArray().Single();

            var code = match.Value;

            // Leading zero does not count toward check digit for 13-digit UCCs.
            if (MaxCodeLength == 13 && code.StartsWith("0"))
                code = code.Substring(startIndex: 1, code.Length - 1);

            var codeWithoutCheckDigit = code.Substring(startIndex: 0, code.Length - 1);
            var calculatedCheckDigit = Calculations.CalculateCheckDigit(codeWithoutCheckDigit);

            return checkDigit == calculatedCheckDigit;
        }
    }
}