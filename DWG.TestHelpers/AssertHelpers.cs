using System;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWG.TestHelpers
{
    public static class AssertHelpers
    {
        public static void AreComparablyEqual(object expected, object actual, string message = null)
        {
            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    CompareChildren = true,
                    IgnoreObjectTypes = true
                });

            var result = comparer.Compare(expected, actual);

            if (!result.Differences.Any())
                return;

            if (!string.IsNullOrEmpty(message))
                Assert.Fail(message + Environment.NewLine + result.DifferencesString);
            else
                Assert.Fail(result.DifferencesString);
        }
    }
}