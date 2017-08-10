using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWG.ProductCode.Tests.Unit
{
    [TestClass]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Unit test")]
    public class CalculationsTests
    {
        [TestMethod]
        public void Calculations_CalculateCheckDigit_629104150021_Returns3()
        {
            const char expected = '3';

            var actual = Calculations.CalculateCheckDigit("629104150021");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculations_CalculateCheckDigit_30024050998_Returns2()
        {
            const char expected = '2';

            var actual = Calculations.CalculateCheckDigit("30024050998");

            Assert.AreEqual(expected, actual);
        }
    }
}