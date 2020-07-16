using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("UserRole", Schema = "dbo")]
    public partial class UserRoleEntity
    {
        [Key]
        public Guid UniqueId { get; set; }
        [ForeignKey("UserUniqueId")]
        public Guid UserUniqueId { get; set; }
        [ForeignKey("RoleUniqueId")]
        public Guid RoleUniqueId { get; set; }

        public virtual RoleEntity RoleUnique { get; set; }
        public virtual UserEntity UserUnique { get; set; }
    }
}
