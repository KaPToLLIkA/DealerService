using DealerPersonalAccount.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealerPersonalAccount.Models.ViewModels
{
    public sealed class UserCreateViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Role { get; set; }

        public User BuildUser()
        {
            var user = new User
            {
                Name = Name,
                PasswordHash = System.Web.Helpers.Crypto.HashPassword(Password)
            };

            return user;
        }
    }
}