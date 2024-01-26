using System;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }


    }
}