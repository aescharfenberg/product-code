using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scharfenberg.ProductCode.Data;

namespace Scharfenberg.ProductCode.Tests.Unit
{
    [TestClass]
    public class ProductCodeTypesTests
    {
        [TestMethod]
        public void ProductCodeTypes_Plu_IsValid_AllIfspGlobalPriceLookupData_True()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;

                // Act
                const bool expected = true;
                var actual = ProductCodeTypes.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }
    }
}
