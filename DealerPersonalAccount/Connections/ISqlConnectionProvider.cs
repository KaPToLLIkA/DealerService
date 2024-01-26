using System.Data.SqlClient;

namespace DealerPersonalAccount.Connections
{
    public interface ISqlConnectionProvider
    {
        SqlConnection Create();
    }
}
