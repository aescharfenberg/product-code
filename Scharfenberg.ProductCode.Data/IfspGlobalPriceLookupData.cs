using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Scharfenberg.ProductCode.Data.Models;

namespace Scharfenberg.ProductCode.Data
{
    public static class IfspGlobalPriceLookupData
    {
        public static IEnumerator<IfspGlobalPriceLookup> GetEmumerator()
        {
            const string commoditiesCsvResourceName = "Scharfenberg.ProductCode.Data.Resources.Commodities_20170331020353.csv";

            var assembly = typeof(IfspGlobalPriceLookupData).GetTypeInfo().Assembly;
            
            using (var resourceStream = assembly.GetManifestResourceStream(commoditiesCsvResourceName))
            {
                using (var reader = new StreamReader(resourceStream))
                {
                    var headerLine = reader.ReadLine();
                    var headings = Tokenize(headerLine);
                    var mappings = MapColumns(headings);

                    while (!reader.EndOfStream)
                    {
                        var detailLine = reader.ReadLine();
                        var details = Tokenize(detailLine);
                        yield return BuildIfspGlobalPriceLookup(details, mappings);
                    }
                }
            }
        }

        private static IfspGlobalPriceLookup BuildIfspGlobalPriceLookup(IReadOnlyList<string> details, IDictionary<int, PropertyInfo> mappings)
        {
            var priceLookup = new IfspGlobalPriceLookup();

            for (var detailIndex = 0; detailIndex < details.Count; ++detailIndex)
            {
                var detail = details[detailIndex];
                var property = mappings[detailIndex];
                property.SetValue(priceLookup, detail);
            }

            return priceLookup;
        }

        private static IDictionary<int, PropertyInfo> MapColumns(IReadOnlyList<string> headings)
        {
            var mappings = new Dictionary<int, PropertyInfo>();

            var columnMappings = IfspGlobalPriceLookup.GetColumnMappings();
            for (var headingIndex = 0; headingIndex < headings.Count; ++headingIndex)
            {
                var heading = headings[headingIndex];
                mappings.Add(headingIndex, columnMappings[heading]);
            }

            return mappings;
        }

        private static string[] Tokenize(string csvLine)
        {
            var tokens = csvLine
                .TrimStart('\"')
                .TrimEnd('\"')
                .Split(new[] {"\",\""}, StringSplitOptions.None);

            return tokens;
        }
    }
}