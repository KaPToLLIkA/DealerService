using System.Configuration;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Connections
{
    internal class DefaultSqlConnectionProvider : ISqlConnectionProvider
    {
        private string _connectionString;

        public DefaultSqlConnectionProvider()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public SqlConnection Provide()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
