using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Role", Schema = "dbo")]
    public partial class RoleEntity
    {
        public RoleEntity()
        {
            UserRole = new HashSet<UserRoleEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRoleEntity> UserRole { get; set; }
    }
}
