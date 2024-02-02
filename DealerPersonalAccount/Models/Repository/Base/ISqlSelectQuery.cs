using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.Base
{
    public interface ISqlSelectQuery<T>
    {
        IEnumerable<T> SelectFrom(SqlConnection connection);
    }
}
