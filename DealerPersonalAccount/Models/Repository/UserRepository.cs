using Dapper;
using DealerPersonalAccount.Connections;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DealerPersonalAccount.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string s_userTable = "[dbo].[User]";
        private const string s_roleTable = "[dbo].[Role]";
        private const string s_paymentTable = "[dbo].[Payment]";

        private const string s_idField = "[Id]";
        private const string s_userNameField = "[Name]";
        private const string s_pswdHashField = "[PasswordHash]";
        private const string s_creationDateField = "[CreationDateTime]";
        private const string s_roleIdField = "[RoleId]";

        private const string s_roleNameField = "[Name]";

        private const string s_paymentAgentIdField = "[AgentId]";
        private const string s_paymentPriceField = "[Price]";

        private SqlConnection _connection;

        public UserRepository(ISqlConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.Create();
        }

        public User Get(int id)
        {
            var sql = $"SELECT " +
                $"{s_userTable}.{s_idField}, " +
                $"{s_userTable}.{s_userNameField}, " +
                $"{s_pswdHashField}, " +
                $"{s_creationDateField}, " +
                $"{s_roleTable}.{s_roleNameField} as 'Role'" +
                $"FROM {s_userTable} INNER JOIN {s_roleTable} " +
                $"ON {s_userTable}.{s_roleIdField} = {s_roleTable}.{s_idField}" +
                $"WHERE {s_userTable}.{s_idField} = @id";

            IEnumerable<User> result = _connection.Query<User>(sql, param: new { id = id.ToString() });

            return result.ElementAt(0);
        }

        public IEnumerable<User> GetAll()
        {
            var sql = $"SELECT " +
                $"{s_userTable}.{s_idField}, " +
                $"{s_userTable}.{s_userNameField}, " +
                $"{s_pswdHashField}, " +
                $"{s_creationDateField}, " +
                $"{s_roleTable}.{s_roleNameField} as 'Role'" +
                $"FROM {s_userTable} INNER JOIN {s_roleTable} " +
                $"ON {s_userTable}.{s_roleIdField} = {s_roleTable}.{s_idField}";

            IEnumerable<User> result = _connection.Query<User>(sql);

            return result;
        }

        public IEnumerable<AgentViewModel> GetAgentAllViewModels()
        {
            var sql = $"SELECT u.{s_userNameField}, SUM(p.{s_paymentPriceField}) as 'TotalEarning' " +
                $"FROM {s_userTable} as u " +
                $"INNER JOIN {s_paymentTable} as p " +
                $"ON u.{s_idField} = p.{s_paymentAgentIdField}" +
                $"GROUP BY p.{s_paymentAgentIdField}, u.{s_userNameField}";

            IEnumerable<AgentViewModel> result = _connection.Query<AgentViewModel>(sql);

            return result;
        }

        public IViewModel<User> GetViewModel(int id)
        {
            return new UserViewModel(Get(id));
        }

        public IEnumerable<IViewModel<User>> GetAllViewModels()
        {
            return GetAll().Select(user => new UserViewModel(user));
        }

        public void Insert(User entity)
        {
            //var sqlRoleGet = "SELECT [Id] FROM [dbo].[Role] WHERE Name = @name";
            //_connection.Query<int>(sqlRoleGet, param: new { name = entity.Role });

            var sql = $"INSERT INTO {s_userTable} " +
                $"({s_userNameField}, " +
                $"{s_pswdHashField}, " +
                $"{s_creationDateField}," +
                $"{s_roleIdField}) VALUES " +
                $"(@name, @hash, SYSDATETIME(), 2)";

            _connection.Execute(sql, param: new { name = entity.Name, hash = entity.PasswordHash });
        }

        public void Remove(User entity)
        {
            Remove(entity.Id);
        }

        public void Remove(int id)
        {
            var sql = $"DELETE FROM {s_userTable} WHERE {s_idField} = @id";

            _connection.Execute(sql, param: new { id = id.ToString() });
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}