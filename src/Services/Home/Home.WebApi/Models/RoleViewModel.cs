using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            UserRole = new HashSet<UserRoleViewModel>();
        }

        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<UserRoleViewModel> UserRole { get; set; }
    }
}
