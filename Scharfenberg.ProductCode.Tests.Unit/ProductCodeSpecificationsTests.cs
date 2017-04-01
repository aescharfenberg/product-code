using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scharfenberg.ProductCode.Data;

namespace Scharfenberg.ProductCode.Tests.Unit
{
    [TestClass]
    public class ProductCodeSpecificationsTests
    {
        [TestMethod]
        public void ProductCodeSpecifications_Plu_IsValid_BaseIfspGlobalPriceLookupData_True()
        {
            var priceLookupEnumerator = IfspGlobalPriceLookupData.GetEmumerator();
            while (priceLookupEnumerator.MoveNext())
            {
                // Arrange
                var priceLookup = priceLookupEnumerator.Current;
                var pluCode = priceLookup.PluCode;

                // Act
                const bool expected = true;
                var actual = ProductCodeSpecifications.Plu.IsValid(pluCode);

                // Assert
                Assert.AreEqual(expected, actual, $"Known valid IFSP Global PLU '{pluCode}' IsValid = {actual}.");
            }
        }
    }
}
