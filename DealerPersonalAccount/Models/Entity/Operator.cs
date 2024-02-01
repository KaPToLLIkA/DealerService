using DealerPersonalAccount.Connections;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class Operator
    {
        public static class Sql
        {
            public static string TableName => SqlFormatter.FormatTableName("Operator");

            public static string IdField => SqlFormatter.FormatFieldName(nameof(Id));

            public static string NameField => SqlFormatter.FormatFieldName(nameof(Name));

            public static string TaxField => SqlFormatter.FormatFieldName(nameof(Tax));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Tax { get; set; }
    }
}