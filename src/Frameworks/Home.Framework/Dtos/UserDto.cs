using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            Employee = new HashSet<EmployeeDto>();
            UserRole = new HashSet<UserRoleDto>();
        }

        public Guid UniqueId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
        public virtual ICollection<UserRoleDto> UserRole { get; set; }
    }
}
