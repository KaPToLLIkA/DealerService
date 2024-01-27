using Dapper;
using DealerPersonalAccount.Connections;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DealerPersonalAccount.Models.Repository
{
    public class PaymentRepository : IRepository<Payment>
    {
        private const string s_paymentTable = "[dbo].[Payment]";
        private const string s_userTable = "[dbo].[User]";
        private const string s_operatorTable = "[dbo].[Operator]";

        private const string s_idField = "[Id]";
        private const string s_creationDateTimeField = "[CreationDateTime]";
        private const string s_closingDateTimeField = "[ClosingDateTime]";
        private const string s_operatorIdField = "[OperatorId]";
        private const string s_agentIdField = "[AgentId]";
        private const string s_priceField = "[Price]";
        private const string s_nameField = "[Name]";

        private SqlConnection _connection;

        public PaymentRepository(ISqlConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.Create();
        }

        public Payment Get(int id)
        {
            var sql = $"SELECT * FROM {s_paymentTable} WHERE {s_idField} = @id";

            IEnumerable<Payment> result = _connection.Query<Payment>(sql, param: new { id = id });

            return result.ElementAt(0);
        }

        public IEnumerable<Payment> GetAll()
        {
            var sql = $"SELECT * FROM {s_paymentTable}";

            IEnumerable<Payment> result = _connection.Query<Payment>(sql);

            return result;
        }

        public IEnumerable<IViewModel<Payment>> GetAllViewModels()
        {
            var sql = $"SELECT " +
                $"p.{s_idField}, " +
                $"p.{s_creationDateTimeField}, " +
                $"p.{s_closingDateTimeField}, " +
                $"u.{s_nameField} as 'Agent', " +
                $"o.{s_nameField} as 'Operator', " +
                $"p.{s_priceField} " +
                $"FROM {s_paymentTable} as p " +
                $"LEFT JOIN {s_userTable} as u " +
                $"ON p.{s_agentIdField} = u.{s_idField} " +
                $"LEFT JOIN {s_operatorTable} as o " +
                $"ON p.{s_operatorIdField} = o.{s_idField}";

            IEnumerable<PaymentViewModel> result = _connection.Query<PaymentViewModel>(sql);

            return result;
        }

        public IViewModel<Payment> GetViewModel(int id)
        {
            var sql = $"SELECT " +
                $"p.{s_idField}, " +
                $"p.{s_creationDateTimeField}, " +
                $"p.{s_closingDateTimeField}, " +
                $"u.{s_nameField} as 'Agent', " +
                $"o.{s_nameField} as 'Operator', " +
                $"p.{s_priceField} " +
                $"FROM {s_paymentTable} as p " +
                $"LEFT JOIN {s_userTable} as u " +
                $"ON p.{s_agentIdField} = u.{s_idField} " +
                $"LEFT JOIN {s_operatorTable} as o " +
                $"ON p.{s_operatorIdField} = o.{s_idField}" +
                $"WHERE p.{s_idField} = @id";

            IEnumerable<PaymentViewModel> result = _connection.Query<PaymentViewModel>(sql, param: new { id = id.ToString() });

            return result.ElementAt(0);
        }

        public void Insert(Payment entity)
        {
            var sql = $"INSERT INTO {s_paymentTable}" +
                $"({s_creationDateTimeField}, " +
                $"{s_priceField})" +
                $"VALUES " +
                $"(SYSDATETIME(), @price)";

            _connection.Execute(sql, param: new { price = entity.Price });
        }

        public void Remove(Payment entity)
        {
            Remove(entity.Id);
        }

        public void Remove(int id)
        {
            var sql = $"DELETE FROM {s_paymentTable} WHERE {s_idField} = @id";

            _connection.Execute(sql, param: new { id = id.ToString() });
        }

        public void Update(Payment entity)
        {
            Update(entity.Id, entity);
        }

        public void Update(int id, Payment entity)
        {
            var sql = $"UPDATE {s_paymentTable} SET " +
                $"{s_closingDateTimeField} = SYSDATETIME(), " +
                $"{s_operatorIdField} = @op, " +
                $"{s_agentIdField} = @agent " +
                $"WHERE {s_idField} = @id";

            _connection.Execute(sql, 
            param: new { 
                op = entity.OperatorId, 
                agent = entity.AgentId, 
                id = id 
            });
        }
    }
}