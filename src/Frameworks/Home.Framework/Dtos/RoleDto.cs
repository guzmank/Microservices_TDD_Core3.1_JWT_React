using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class RoleDto
    {
        public RoleDto()
        {
            UserRole = new List<UserRoleDto>();
        }

        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<UserRoleDto> UserRole { get; set; }
    }
}
