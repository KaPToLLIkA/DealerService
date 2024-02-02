using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectAgentById : ISqlSelectQuery<Agent>
    {
        private int _targetId;

        public SelectAgentById(int id)
        {
            _targetId = id;
        }

        public IEnumerable<Agent> SelectFrom(SqlConnection connection)
        {
            string sql = $"{Agent.Sql.SelectQueryHeader} " +
                $"WHERE {Agent.Sql.IdField} = @id;";

            return connection.Query<Agent>(sql, param: new { id = _targetId });
        }
    }
}