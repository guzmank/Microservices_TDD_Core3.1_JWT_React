using System;
using System.Collections.Generic;

namespace Home.Identity.WebApi.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            UserRole = new HashSet<UserRoleViewModel>();
        }

        public Guid UniqueId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<UserRoleViewModel> UserRole { get; set; }
    }
}
