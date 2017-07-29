using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scharfenberg.ProductCode.Data;
using Scharfenberg.TestHelpers;

namespace Scharfenberg.ProductCode.Tests.Unit
{
    [TestClass]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Unit test")]
    public class ProductCodeSpecificationsTests
    {
        [TestMethod]
        public void ProductCodeSpecifications_Plu_IsValid_IfspGlobalPriceLookupData_ReturnsTrue()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                const bool expected = true;

                // Act
                var actual = ProductCodeSpecifications.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }

        [TestMethod]
        public void ProductCodeSpecifications_Plu_IsValid_IfspGlobalPriceLookupDataWithCheckDigits_ReturnsTrue()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                var checkDigit = pluCode + Calculations.CalculateCheckDigit(pluCode);
                var pluCodeWithCheckDigit = checkDigit;
                const bool expected = false;

                // Act
                var actual = ProductCodeSpecifications.Plu.IsValid(pluCodeWithCheckDigit);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' with check digit '{checkDigit}' (invalid) IsValid = {actual}.");
            }
        }

        [TestMethod]
        public void ProductCodeSpecifications_Plu_Parse_IfspGlobalPriceLookupData_ReturnsTrue()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;
                var expected =
                    new Models.ProductCode
                    {
                        Code = pluCode,
                        CheckDigit = null,
                        ProductCodeType = ProductCodeSpecifications.Plu
                    };

                // Act
                var actual = ProductCodeSpecifications.Plu.Parse(pluCode);

                // Assert
                AssertHelpers.AreComparablyEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }
    }
}