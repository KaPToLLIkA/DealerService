using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectOperatorById : ISqlSelectQuery<Operator>
    {
        private int _targetId;

        public SelectOperatorById(int id)
        {
            _targetId = id;
        }

        public IEnumerable<Operator> SelectFrom(SqlConnection connection)
        {
            string sql = $"{Operator.Sql.SelectQueryHeader} " +
                $"WHERE {Operator.Sql.IdField} = @id";

            return connection.Query<Operator>(sql, param: new { id = _targetId });
        }
    }
}