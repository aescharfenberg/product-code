using System.Text.RegularExpressions;
using DWG.ProductCode.Contracts;

namespace DWG.ProductCode
{
    /// <see cref="http://www.taltech.com/barcodesoftware/symbologies/upc"/>
    public static class Converters
    {
        public static string ConvertToUpcE(string upcA)
        {
            return null;
        }

        public static string ConvertToUpcA(string upcE)
        {
            if (upcE == null)
                return null;

            if (upcE.Length != 6)
                return null;

            Match match;

            match = RegularExpressions.UpcE.AbManufacturerCodeRegex.Match(upcE);
            if (match.Success)
                return null;

            return null;
        }
    }
}
