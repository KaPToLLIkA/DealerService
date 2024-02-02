using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectAllOperators : ISqlSelectQuery<Operator>
    {
        public IEnumerable<Operator> SelectFrom(SqlConnection connection)
        {
            string sql = $"{Operator.Sql.SelectQueryHeader};";

            return connection.Query<Operator>(sql);
        }
    }
}