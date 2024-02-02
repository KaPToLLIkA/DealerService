using DealerPersonalAccount.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DealerPersonalAccount.Models.Repository.Base
{
    public abstract class ARepository<T>
    {
        private ISqlConnectionProvider _connectionProvider;

        public ARepository(ISqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        protected void ExecuteQuery(Action<SqlConnection> query)
        {
            try
            {
                using (SqlConnection connection = _connectionProvider.Provide())
                {
                    query(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.{nameof(ExecuteQuery)} " +
                    $"experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.{nameof(ExecuteQuery)} " +
                    $"experienced a SQL exception", ex);
            }
        }

        public abstract void Insert(T entity);
        public abstract void Remove(T entity);
        public abstract void Update(T entity);

        public abstract IEnumerable<T> Select(ISqlSelectQuery<T> specification);
    }
}
