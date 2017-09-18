using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scharfenberg.ProductCode.Data;
using Scharfenberg.ProductCode.Tests.Unit.Models;
using Scharfenberg.TestHelpers;

namespace Scharfenberg.ProductCode.Tests.Unit
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
                new Models.ProductCode
                {
                    Code = code,
                    CheckDigit = '2',
                    ProductCodeType = new ProductCodeType
                    {
                        Moniker = "UPC-A",
                        CodeLength = 12
                    }
                };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCodeTypes_Interopolate_0300240509982_ProductCodeTypeUpcA()
        {
            // Arrange
            const string code = "0300240509982";
            var expected =
                new Models.ProductCode
                {
                    Code = code,
                    CheckDigit = '2',
                    ProductCodeType = new ProductCodeType
                    {
                        Moniker = "EAN",
                        CodeLength = 13
                    }
                };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected, actual);
        }
        
         [TestMethod]
        public void ProductCodeTypes_Interopolate_025200000148_ProductCodeTypeUpcA()
        {
            // Arrange
            const string code = "250142";
            var expected =
                new Models.ProductCode
                {
                    Code = code,
                    CheckDigit = '2',
                    ProductCodeType = new ProductCodeType
                    {
                        Moniker = "UPCE",
                        CodeLength = 8
                    }
                };

            // Act
            var actual = ProductCodeTypes.Interpolate(code);

            // Assert
            AssertHelpers.AreComparablyEqual(expected.Code, actual.Code);
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