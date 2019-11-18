using System.Text.RegularExpressions;

namespace DWG.ProductCode
{
    /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
    public static class Converters
    {
        public static string ConvertToUpcE(string code)
        {
            return null;
        }

        /// <summary>
        /// Converts the UPC-E provided to a UPC-A.
        /// </summary>
        /// <param name="code">The UPC-E to convert to a UPC-A.</param>
        /// <returns>The UPC-A corresponding to the UPC-E provided.</returns>
        public static string ConvertToUpcA(string code)
        {
            if (code == null)
                return null;

            if (code.Length != 6)
                return null;

            Match match;

            match = RegularExpressions.UpcE.AbManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "00000");

            match = RegularExpressions.UpcE.Ab1ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "10000");

            match = RegularExpressions.UpcE.Ab2ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "20000");

            match = RegularExpressions.UpcE.AbcManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = RegularExpressions.UpcE.AbcdManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = RegularExpressions.UpcE.Abcde5ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = RegularExpressions.UpcE.Abcde6ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = RegularExpressions.UpcE.Abcde7ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = RegularExpressions.UpcE.Abcde8ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = RegularExpressions.UpcE.Abcde9ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            return null;
        }

        /// <summary>
        /// Builds a UPC-A from the UPC-E regular expression match provided.
        /// </summary>
        /// <param name="match">The UPC-E regular expression match.</param>
        /// <param name="separator">The separator sequence that should come between the manufacturer code and the item number.</param>
        /// <returns>A UPC-A built from the UPC-E regular expression match provided.</returns>
        private static string BuildUpcA(Match match, string separator)
        {
            var manufacturerCodeGroup = match.Groups["manufacturerCode"];
            var manufacturerCode = manufacturerCodeGroup.Value;

            var itemNumberGroup = match.Groups["itemNumber"];
            var itemNumber = itemNumberGroup.Value;

            var codeWithoutCheckDigit = $"0{manufacturerCode}{separator}{itemNumber}";
            var checkDigit = Calculations.CalculateCheckDigit(codeWithoutCheckDigit);

            var result = codeWithoutCheckDigit + checkDigit;
            return result;
        }
    }
}
