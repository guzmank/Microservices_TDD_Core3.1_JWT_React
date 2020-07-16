using System;

namespace Home.Identity.WebApi.Models
{
    public class UserRoleViewModel
    {
        public Guid UniqueId { get; set; }
        public Guid UserUniqueId { get; set; }
        public Guid RoleUniqueId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual RoleViewModel RoleUnique { get; set; }
        public virtual UserViewModel UserUnique { get; set; }
    }
}
