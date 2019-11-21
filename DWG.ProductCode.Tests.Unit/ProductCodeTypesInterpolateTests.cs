using System.Diagnostics.CodeAnalysis;
using DWG.ProductCode.Data;
using DWG.ProductCode.Models;
using DWG.ProductCode.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWG.ProductCode.Tests.Unit
{
    [TestClass]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Unit test")]
    public class ProductCodeTypesInterpolateTests
    {
        [TestMethod]
        public void ProductCodeTypes_Interpolate_300240509982_ProductCodeTypeUpcA()
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
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_0300240509982_ProductCodeTypeEan()
        {
            // Arrange
            const string code = "0300240509982";
            var expected = new EuropeanArticleNumber
            {
                Code = code,
                CheckDigit = '2'
            };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_025200000148_ProductCodeTypeUpcA()
        {
            // Arrange
            const string code = "025200000148";
            var expected = new UniversalProductCodeTypeA 
            {
                Code = code, 
                CheckDigit = '8'
            };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_250142_ProductCodeTypeUpcE()
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
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_2501428_ProductCodeTypeUpcE()
        {
            // Arrange
            const string code = "250142";
            var expected = new UniversalProductCodeTypeE
            {
                Code = "02501428",
                CheckDigit = '8'
            };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_02501428_ProductCodeTypeUpcE()
        {
            // Arrange
            const string code = "02501428";
            var expected = new UniversalProductCodeTypeE
            {
                Code = "02501428",
                CheckDigit = '8'
            };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_7808772040230_ProductCodeTypeEan()
        {
            // Arrange
            const string code = "7808772040230";
            var expected = new EuropeanArticleNumber
            {
                Code = code,
                CheckDigit = '0'
            };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_8412345000001_ReturnsNull()
        {
            // Arrange
            const string code = "8412345000001";

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Interpolate_8412345000003_ProductCodeTypeEan()
        {
            // Arrange
            const string code = "8412345000003";
            var expected = new EuropeanArticleNumber
            {
                Code = code,
                CheckDigit = '3'
            };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_00300240509982_ProductCodeTypeUpcA()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                const bool expected = true;

                // Act
                var actual = ProductCodeTypes.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_000300240509982_ProductCodeTypeUpcA()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                const bool expected = true;

                // Act
                var actual = ProductCodeTypes.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_0000300240509982_ProductCodeTypeUpcA()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                const bool expected = true;

                // Act
                var actual = ProductCodeTypes.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }

        [TestMethod]
        public void ProductCodeTypes_Parse_00000300240509982_ProductCodeTypeUpcA()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                const bool expected = true;

                // Act
                var actual = ProductCodeTypes.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }
    }
}