namespace DWG.ProductCode.TestHelpers
{
    /// <summary>
    /// Independently production-verified UPC-E to UPC-A converter courtesy of CQuest America, Inc.
    /// </summary>
    public static class UpcEConverter
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
                    upcEValue = upcE.Substring(startIndex: 1, length: 6);
                    break;
                case 8:
                    upcEValue = upcE.Substring(startIndex: 1, length: 6);
                    break;
                default:
                    return "";

            }
            var digit1 = upcEValue.Substring(startIndex: 0, length: 1);
            var digit2 = upcEValue.Substring(startIndex: 1, length: 1);
            var digit3 = upcEValue.Substring(startIndex: 2, length: 1);
            var digit4 = upcEValue.Substring(startIndex: 3, length: 1);
            var digit5 = upcEValue.Substring(startIndex: 4, length: 1);
            var digit6 = upcEValue.Substring(startIndex: 5, length: 1);

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
