using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scharfenberg.ProductCode.Tests.Unit
{
    [TestClass]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Unit test")]
    public class CalculationsTests
    {
        [TestMethod]
        public void Calculations_CalculateCheckDigit_Gtin629104150021_Returns3()
        {
            const char expected = '3';

            var actual = Calculations.CalculateCheckDigit("629104150021");

            Assert.AreEqual(expected, actual);
        }
    }
}
