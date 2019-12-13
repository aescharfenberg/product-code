namespace DWG.ProductCode.TestHelpers
{
    /// <summary>
    /// Independently production-verified UPC-E to UPC-A converter courtesy of CQuest America, Inc.
    /// </summary>
    internal static class UpcEConverter
    {
        public static string UpcEtoA(string upcE)
        {
            string upcEValue;

            switch (upcE.Length)
            {
                case 6:
                    upcEValue = upcE;
                    break;
                case 7:
                    upcEValue = upcE.Substring(1, 6);
                    break;
                case 8:
                    upcEValue = upcE.Substring(1, 6);
                    break;
                default:
                    return "";

            }
            var digit1 = upcEValue.Substring(0, 1);
            var digit2 = upcEValue.Substring(1, 1);
            var digit3 = upcEValue.Substring(2, 1);
            var digit4 = upcEValue.Substring(3, 1);
            var digit5 = upcEValue.Substring(4, 1);
            var digit6 = upcEValue.Substring(5, 1);

            string manufacturersId;
            string itemNumber;

            switch (digit6)
            {
                case "0":
                case "1":
                case "2":
                    {
                        manufacturersId = digit1 + digit2 + digit6 + "00";
                        itemNumber = "00" + digit3 + digit4 + digit5;
                        break;
                    }
                case "3":
                    manufacturersId = digit1 + digit2 + digit3 + "00";
                    itemNumber = "000" + digit4 + digit5;
                    break;
                case "4":
                    manufacturersId = digit1 + digit2 + digit3 + digit4 + "0";
                    itemNumber = "0000" + digit5;
                    break;
                default:
                    manufacturersId = digit1 + digit2 + digit3 + digit4 + digit5;
                    itemNumber = "0000" + digit6;
                    break;
            }

            var barcode = $"0{manufacturersId}{itemNumber}";
            var checkDigit = Calculations.CalculateCheckDigit(barcode);
            var upcA = barcode + checkDigit;
            return upcA;
        }
    }
}
