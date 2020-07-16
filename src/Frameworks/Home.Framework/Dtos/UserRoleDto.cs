using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class UserRoleDto
    {
        public Guid UniqueId { get; set; }
        public Guid UserUniqueId { get; set; }
        public Guid RoleUniqueId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual RoleDto RoleUnique { get; set; }
        public virtual UserDto UserUnique { get; set; }
    }
}
