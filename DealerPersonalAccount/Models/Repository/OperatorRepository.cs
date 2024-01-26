using Dapper;
using DealerPersonalAccount.Connections;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DealerPersonalAccount.Models.Repository
{
    public class OperatorRepository : IRepository<Operator>
    {
        private const string s_tableName = "[dbo].[Operator]";

        private const string s_idField = "[Id]";
        private const string s_nameField = "[Name]";
        private const string s_taxField = "[Tax]";

        private SqlConnection _connection;

        public OperatorRepository(ISqlConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.Create();
        }

        public Operator Get(int id)
        {
            var sql = $"SELECT * FROM {s_tableName} WHERE {s_idField} = @id";

            IEnumerable<Operator> result = _connection.Query<Operator>(sql, param: new { id = id.ToString() });

            return result.ElementAt(0);
        }

        public IEnumerable<Operator> GetAll()
        {
            var sql = $"SELECT * FROM {s_tableName}";

            IEnumerable<Operator> result = _connection.Query<Operator>(sql);

            return result;
        }

        public void Insert(Operator entity)
        {
            var sql = $"INSERT INTO {s_tableName} ({s_nameField}, {s_taxField}) VALUES (@name, @tax)";

            _connection.Execute(sql, param: new { name = entity.Name, tax = entity.Tax.ToString() });
        }

        public void Remove(Operator entity)
        {
            Remove(entity.Id);
        }

        public void Remove(int id)
        {
            var sql = $"DELETE FROM {s_tableName} WHERE {s_idField} = @id";

            _connection.Execute(sql, param: new { id = id.ToString() });
        }

        public void Update(Operator entity)
        {
            Update(entity.Id, entity);
        }

        public void Update(int id, Operator entity)
        {
            var sql = $"UPDATE {s_tableName} SET " +
                $"{s_nameField} = @name, " +
                $"{s_taxField} = @tax" +
                $"WHERE {s_idField} = @id";

            _connection.Execute(sql, param: new { name = entity.Name, tax = entity.Tax.ToString() });
        }

        public IEnumerable<IViewModel<Operator>> GetAllViewModels()
        {
            return GetAll().Select(operatr => new OperatorViewModel(operatr));
        }

        public IViewModel<Operator> GetViewModel(int id)
        {
            Operator operatr = Get(id);
            return new OperatorViewModel(operatr);
        }
    }
}