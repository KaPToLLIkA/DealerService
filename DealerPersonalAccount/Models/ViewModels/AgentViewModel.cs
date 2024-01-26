using DealerPersonalAccount.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerPersonalAccount.Models.ViewModels
{
    public sealed class AgentViewModel : IViewModel<User>
    {
        public AgentViewModel(string name, double totalEarning) 
        {
            Name = name;
            TotalEarning = totalEarning;
        }

        public string Name { get; set; }

        public double TotalEarning { get; set; }
    }
}