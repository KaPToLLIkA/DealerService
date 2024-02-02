using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectAllPayments : ISqlSelectQuery<Payment>
    {
        public IEnumerable<Payment> SelectFrom(SqlConnection connection)
        {
            string sql = $"{Payment.Sql.SelectQueryHeader};";

            return connection.Query<Payment>(sql);
        }
    }
}