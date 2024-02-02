using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectUsersByName : ISqlSelectQuery<User>
    {
        private string _targetName;

        public SelectUsersByName(string name)
        {
            _targetName = $"'%{name}%'";
        }

        public IEnumerable<User> SelectFrom(SqlConnection connection)
        {
            string sql = $"{User.Sql.SelectQueryHeader} " +
                $"WHERE {User.Sql.NameField} LIKE @targetName;";

            return connection.Query<User>(sql, param: new { targetName = _targetName });
        }
    }
}