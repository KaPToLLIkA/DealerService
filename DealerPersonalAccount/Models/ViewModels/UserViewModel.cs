using DealerPersonalAccount.Models.Entity;
using System;

namespace DealerPersonalAccount.Models.ViewModels
{
    public sealed class UserViewModel : IViewModel<User>
    {
        public UserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            CreationDateTime = user.CreationDateTime;
            Role = user.RoleType;

        }

        public int Id { get; set; } 

        public string Name { get; set; }

        public DateTime CreationDateTime { get; set; }

        public RoleType Role { get; set; }

        public string RoleString => Role.ToString();
    }
}