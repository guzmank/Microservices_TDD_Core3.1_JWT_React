using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("User", Schema = "dbo")]
    public partial class UserEntity
    {
        public UserEntity()
        {
            Employee = new HashSet<EmployeeEntity>();
            UserRole = new HashSet<UserRoleEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<EmployeeEntity> Employee { get; set; }
        public virtual ICollection<UserRoleEntity> UserRole { get; set; }
    }
}
