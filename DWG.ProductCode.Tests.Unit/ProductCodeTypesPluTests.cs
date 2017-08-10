using System.Diagnostics.CodeAnalysis;
using DWG.ProductCode.Data;
using DWG.ProductCode.Tests.Unit.Models;
using DWG.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWG.ProductCode.Tests.Unit
{
    [TestClass]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Unit test")]
    public class ProductCodeTypesPluTests
    {
        [TestMethod]
        public void ProductCodeTypes_Plu_IsValid_IfspGlobalPriceLookupData_ReturnsTrue()
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
        public void ProductCodeTypes_Plu_IsValid_IfspGlobalPriceLookupDataWithCheckDigits_ReturnsTrue()
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
                var actual = ProductCodeTypes.Plu.IsValid(pluCodeWithCheckDigit);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' with check digit '{checkDigit}' (invalid) IsValid = {actual}.");
            }
        }

        [TestMethod]
        public void ProductCodeTypes_Plu_Parse_IfspGlobalPriceLookupData_ReturnsExpectedPluProductCode()
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
                        ProductCodeType = new ProductCodeType
                        {
                            Moniker = ProductCodeTypes.Plu.Moniker,
                            CodeLength = pluCode.Length
                        }
                    };

                // Act
                var actual = ProductCodeTypes.Plu.Parse(pluCode);

                // Assert
                AssertHelpers.AreComparablyEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' not parsed as expected.");
            }
        }
    }
}