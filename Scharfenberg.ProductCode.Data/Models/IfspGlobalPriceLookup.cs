using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Scharfenberg.ProductCode.Data.Models
{
    public class IfspGlobalPriceLookup
    {
        private static readonly IDictionary<string, PropertyInfo> _columnMappings = (
            from p in typeof(IfspGlobalPriceLookup).GetProperties()
            let columnAttribute = p.GetCustomAttribute<ColumnAttribute>()
            where columnAttribute != null
            select new
            {
                ColumnName = columnAttribute.Name,
                Property = p
            }).ToDictionary(x => x.ColumnName, x => x.Property);

        [Column("PLU")]
        public string PluCode { get; set; }

        [Column("CATEGORY")]
        public string Category { get; set; }

        [Column("COMMODITY")]
        public string Commodity { get; set; }

        [Column("VARIETY")]
        public string Variety { get; set; }

        [Column("ADDITIONAL VARIETY INFO")]
        public string AdditionalVarietyInfo { get; set; }

        [Column("SIZE")]
        public string Size { get; set; }

        [Column("NA SIZE")]
        public string NaSize { get; set; }

        [Column("ROW SIZE")]
        public string RowSize { get; set; }

        [Column("RESTRICTIONS")]
        public string Restrictions { get; set; }

        [Column("NOTES")]
        public string Notes { get; set; }

        [Column("AKA")]
        public string AlsoKnownAs { get; set; }

        [Column("TRADEMARK")]
        public string Trademark { get; set; }

        [Column("BOTANICAL NAME")]
        public string BotanicalName { get; set; }

        [Column("REVISION DATE")]
        public string RevisionDate { get; set; }

        [Column("DATE ADDED")]
        public string DateAdded { get; set; }

        [Column("GPC")]
        public string Gpc { get; set; }

        [Column("IMAGE")]
        public string Image { get; set; }

        public static IDictionary<string, PropertyInfo> GetColumnMappings()
        {
            return _columnMappings;
        }
    }
}