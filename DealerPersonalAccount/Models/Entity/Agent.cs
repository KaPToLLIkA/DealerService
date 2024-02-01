using DealerPersonalAccount.Connections;
using System;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class Agent
    {
        public static class Sql
        {
            public static string TableName => SqlFormatter.FormatTableName("Agent");

            public static string IdField => SqlFormatter.FormatFieldName(nameof(Id));

            public static string TotalEarningField => SqlFormatter.FormatFieldName(nameof(TotalEarning));

            public static string UserIdField => SqlFormatter.FormatFieldName(nameof(UserId));
        }

        public int Id { get; set; }
        public decimal TotalEarning { get; set; }
        public int UserId { get; set; }

        // from User table
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}