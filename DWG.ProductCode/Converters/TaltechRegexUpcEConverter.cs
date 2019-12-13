using System;
using System.Text.RegularExpressions;
using DWG.ProductCode.Contracts;
using DWG.ProductCode.Models;

namespace DWG.ProductCode.Converters
{
    internal class TaltechRegexUpcEConverter : IUpcEConverter
    {
        public UniversalProductCodeTypeE Source { get; }

        public TaltechRegexUpcEConverter(UniversalProductCodeTypeE source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public IProductCode ToUpcA()
        {
            var result = ConvertToUpcA(Source.Code.Substring(1, 6));
            return new UniversalProductCodeTypeA
            {
                Code = result
            };
        }

        public IProductCode ToEan()
        {
            throw new NotImplementedException();
        }

        public static string ConvertToUpcA(string code)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code));

            if (code.Length != 6)
                throw new ArgumentException(ExceptionMessages.UpcELengthNotEqualTo6, nameof(code));

            Match match;

            match = Regexes.AbManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "00000");

            match = Regexes.Ab1ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "10000");

            match = Regexes.Ab2ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "20000");

            match = Regexes.AbcManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = Regexes.AbcdManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = Regexes.Abcde5ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = Regexes.Abcde6ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = Regexes.Abcde7ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = Regexes.Abcde8ManufacturerCodeRegex.Match(code);
            if (match.Success)
                return BuildUpcA(match, "0000");

            match = Regexes.Abcde9ManufacturerCodeRegex.Match(code);
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

        /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
        private static class Regexes
        {
            /// <summary>
            /// 0ab00000cdeX abcde0X Manufacturer code must have 2 leading digits with 3 trailing zeros and the item number is limited to 3 digits(000 to 999).
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex AbManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{2})(?<itemNumber>[0-9]{3})0$");

            /// <summary>
            /// 0ab10000cdeX abcde1X Manufacturer code must have 3 leading digits ending with "1" and 2 trailing zeros.The item number is limited to 3 digits.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Ab1ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{2})(?<itemNumber>[0-9]{3})1$");

            /// <summary>
            /// 0ab20000cdeX abcde2X Manufacturer code must have 3 leading digits ending with "2" and 2 trailing zeros. The item number is limited to 3 digits.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Ab2ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{2})(?<itemNumber>[0-9]{3})2$");

            /// <summary>
            /// 0abc00000deX abcde3X Manufacturer code must have 3 leading digits and 2 trailing zeros. The item number is limited to 2 digits (00 to 99).
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex AbcManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{3})(?<itemNumber>[0-9]{2})3$");

            /// <summary>
            /// 0abcd00000eX abcde4X Manufacturer code must have 4 leading digits with 1 trailing zero and the item number is limited to 1 digit(0 to9).
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex AbcdManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{4})(?<itemNumber>[0-9]{1})4$");

            /// <summary>
            /// 0abcde00005X abcde5X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde5ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{5})(?<itemNumber>5)$");

            /// <summary>
            /// 0abcde00006X abcde6X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde6ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{5})(?<itemNumber>6)$");

            /// <summary>
            /// 0abcde00007X abcde7X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde7ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{5})(?<itemNumber>7)$");

            /// <summary>
            /// 0abcde00008X abcde8X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde8ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{5})(?<itemNumber>8)$");

            /// <summary>
            /// 0abcde00009X abcde9X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde9ManufacturerCodeRegex = new Regex("^(?<manufacturerCode>[0-9]{5})(?<itemNumber>9)$");
        }
    }
}
