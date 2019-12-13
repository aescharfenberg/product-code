using DWG.ProductCode.Data;
using DWG.ProductCode.Models;
using DWG.ProductCode.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWG.ProductCode.Tests.Unit
{
    [TestClass]
    public class InterpolateTests
    {
        [TestMethod]
        public void Interpolate_FromString_300240509982_ProductCodeTypeUpcA()
        {
            // Arrange
            const string code = "300240509982";
            var expected =
                new UniversalProductCodeTypeA
                {
                    Code = code,
                    CheckDigit = '2'
                };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void Interpolate_FromString_0300240509982_ProductCodeTypeEan()
        {
            // Arrange
            const string code = "0300240509982";
            var expected = new EuropeanArticleNumber
            {
                Code = code,
                CheckDigit = '2'
            };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void Interpolate_FromString_025200000148_ProductCodeTypeUpcA()
        {
            // Arrange
            const string code = "025200000148";
            var expected = new UniversalProductCodeTypeA 
            {
                Code = code, 
                CheckDigit = '8'
            };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void Interpolate_FromString_250142_ProductCodeTypeUpcE()
        {
            // Arrange
            const string code = "250142";
            var expected =
                new UniversalProductCodeTypeE
                {
                    Code = "02501428",
                    CheckDigit = '8'
                };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void Interpolate_FromString_2501428_ProductCodeTypeUpcE()
        {
            // Arrange
            const string code = "250142";
            var expected = new UniversalProductCodeTypeE
            {
                Code = "02501428",
                CheckDigit = '8'
            };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void Interpolate_FromString_02501428_ProductCodeTypeUpcE()
        {
            // Arrange
            const string code = "02501428";
            var expected = new UniversalProductCodeTypeE
            {
                Code = "02501428",
                CheckDigit = '8'
            };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void Interpolate_FromString_7808772040230_ProductCodeTypeEan()
        {
            // Arrange
            const string code = "7808772040230";
            var expected = new EuropeanArticleNumber
            {
                Code = code,
                CheckDigit = '0'
            };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void Interpolate_FromString_8412345000001_ReturnsNull()
        {
            // Arrange
            const string code = "8412345000001";

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Interpolate_FromString_8412345000003_ProductCodeTypeEan()
        {
            // Arrange
            const string code = "8412345000003";
            var expected = new EuropeanArticleNumber
            {
                Code = code,
                CheckDigit = '3'
            };

            // Act
            var actual = Interpolate.FromString(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_300240509982_ProductCodeTypeUpcA()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_0300240509982_ProductCodeTypeUpcA()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_00300240509982_ProductCodeTypeUpcA()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_000300240509982_ProductCodeTypeUpcA()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_0000300240509982_ProductCodeTypeUpcA()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_00000300240509982_ProductCodeTypeUpcA()
        {
            Assert.Inconclusive();
        }
    }
}