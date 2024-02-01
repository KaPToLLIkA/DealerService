using DealerPersonalAccount.Connections;
using System;
using System.Xml.Linq;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class Payment
    {
        public static class Sql
        {
            public static string TableName => SqlFormatter.FormatTableName("Payment");

            public static string IdField => SqlFormatter.FormatFieldName(nameof(Id));

            public static string CreationDateTimeField => SqlFormatter.FormatFieldName(nameof(CreationDateTime));

            public static string ClosingDateTimeField => SqlFormatter.FormatFieldName(nameof(ClosingDateTime));

            public static string OperatorIdField => SqlFormatter.FormatFieldName(nameof(OperatorId));

            public static string AgentIdField => SqlFormatter.FormatFieldName(nameof(AgentId));

            public static string PriceField => SqlFormatter.FormatFieldName(nameof(Price));
        }

        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ClosingDateTime { get; set; }
        public int? OperatorId { get; set; }
        public int? AgentId { get; set; }
        public decimal Price { get; set; }
    }
}