using DealerPersonalAccount.Connections;
using System;
using System.Reflection.Emit;

namespace DealerPersonalAccount.Models.Entity
{
    public class User
    {
        public static class Sql
        {
            public static string TableName => SqlFormatter.FormatTableName("User");

            public static string IdField => SqlFormatter.FormatFieldName(nameof(Id));

            public static string NameField => SqlFormatter.FormatFieldName(nameof(Name));

            public static string PasswordHashField => SqlFormatter.FormatFieldName(nameof(PasswordHash));

            public static string CreationDateTimeField => SqlFormatter.FormatFieldName(nameof(CreationDateTime));

            public static string RoleIdField => SqlFormatter.FormatFieldName(nameof(RoleId));

            public static string SelectQueryHeader => 
                $"SELECT " +
                $"{IdField}," +
                $"{NameField}," +
                $"{CreationDateTimeField}," +
                $"{PasswordHashField}," +
                $"{RoleIdField}," +
                $"FROM {TableName}";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDateTime { get; set; }
        public Role RoleId { get; set; }
    }
}