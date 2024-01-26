using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class User
    {
        private static readonly Dictionary<string, RoleType> s_roleTypesMap = new Dictionary<string, RoleType>()
        {
            {"admin", RoleType.Admin},
            {"agent", RoleType.Agent},
        };

        private string _role;

        public int Id { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string Role {
            get => RoleType.ToString();
            set => _role = value;
        }

        public RoleType RoleType => s_roleTypesMap[_role];
    }
}