using Dapper;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.SelectQuery
{
    public class SelectAllUsers : ISqlSelectQuery<User>
    {
        public IEnumerable<User> SelectFrom(SqlConnection connection)
        {
            string sql = $"{User.Sql.SelectQueryHeader} " +
                $"ORDER BY {User.Sql.NameField} DESC;";

            return connection.Query<User>(sql);
        }
    }
}