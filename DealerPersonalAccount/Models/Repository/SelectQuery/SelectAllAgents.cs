using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectAllAgents : ISqlSelectQuery<Agent>
    {
        public IEnumerable<Agent> SelectFrom(SqlConnection connection)
        {
            string sql = $"{Agent.Sql.SelectQueryHeader} " +
                $"ORDER BY {User.Sql.NameField} DESC;";

            return connection.Query<Agent>(sql);
        }
    }
}