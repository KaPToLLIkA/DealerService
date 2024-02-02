namespace DealerPersonalAccount.Connections
{
    public class SqlFormatter
    {
        public static string FormatFieldName(string fieldName)
        {
            return $"[{fieldName}]";
        }

        public static string FormatTableName(string tableName)
        {
            return $"[{tableName}]";
        }
    }
}