using System.Text.RegularExpressions;

namespace DWG.ProductCode
{
    internal static class RegularExpressions
    {
        internal static class PriceLookup
        {
            internal static readonly Regex InitialRegex = new Regex("^[0-9]{4,6}$");

            internal static readonly Regex Series3000Regex = new Regex("^(?<code>([0]|[9])?(3[0-9]{3}))$");

            internal static readonly Regex Series4000Regex = new Regex("^(?<code>([0]|[9])?(4[0-9]{3}))$");

            internal static readonly Regex Series83000Regex = new Regex("^(?<code>8(3[0-9]{3}))$");

            internal static readonly Regex Series84000Regex = new Regex("^(?<code>8(4[0-9]{3}))$");
        }

        internal static class UpcA
        {
            /// <summary>
            /// 0ab00000cdeX abcde0X Manufacturer code must have 2 leading digits with 3 trailing zeros and the item number is limited to 3 digits(000 to 999).
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex AbManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{2})0(0{4})(?<itemNumber>[0-9]{3})(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0ab10000cdeX abcde1X Manufacturer code must have 3 leading digits ending with "1" and 2 trailing zeros.The item number is limited to 3 digits.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Ab1ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{2})1(0{4})(?<itemNumber>[0-9]{3})(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0ab20000cdeX abcde2X Manufacturer code must have 3 leading digits ending with "2" and 2 trailing zeros. The item number is limited to 3 digits.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Ab2ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{2})2(0{4})(?<itemNumber>[0-9]{3})(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abc00000deX abcde3X Manufacturer code must have 3 leading digits and 2 trailing zeros. The item number is limited to 2 digits (00 to 99).
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex AbcManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{3})0(0{4})(?<itemNumber>[0-9]{2})(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abcd00000eX abcde4X Manufacturer code must have 4 leading digits with 1 trailing zero and the item number is limited to 1 digit(0 to9).
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex AbcdManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{4})0(0{4})(?<itemNumber>[0-9]{1})(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abcde00005X abcde5X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde5ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{5})(0{4})(?<itemNumber>5)(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abcde00006X abcde6X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde6ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{5})(0{4})(?<itemNumber>6)(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abcde00007X abcde7X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde7ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{5})(0{4})(?<itemNumber>7)(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abcde00008X abcde8X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde8ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{5})(0{4})(?<itemNumber>8)(?<checkDigit>[0-9])$");

            /// <summary>
            /// 0abcde00009X abcde9X Manufacturer code has all 5 digits. The item number is limited to a single digit consisting of either 5,6,7,8 or 9.
            /// </summary>
            /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
            internal static readonly Regex Abcde9ManufacturerCodeRegex = new Regex("^0(?<manufacturerCode>[0-9]{5})(0{4})(?<itemNumber>9)(?<checkDigit>[0-9])$");
        }
    }
}