using System.Linq;

namespace DWG.ProductCode
{
    public static class Calculations
    {
        /// <see cref="http://www.gs1.org/how-calculate-check-digit-manually"/>
        public static char CalculateCheckDigit(string code)
        {
            var evenSum = 0;
            var oddSum = 0;

            for (var position = 1; position <= code.Length; ++position)
            {
                var index = code.Length - position;
                var digit = (int)char.GetNumericValue(code, index);

                if (position % 2 == 0)
                    evenSum += digit;
                else
                    oddSum += digit;
            }

            var checkDigit = (10 - (oddSum * 3 + evenSum) % 10) % 10;
            return checkDigit.ToString().ToCharArray().Single();
        }
    }
}