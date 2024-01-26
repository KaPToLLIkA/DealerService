using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerPersonalAccount.Models.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<AgentViewModel> GetAgentAllViewModels();
    }
}