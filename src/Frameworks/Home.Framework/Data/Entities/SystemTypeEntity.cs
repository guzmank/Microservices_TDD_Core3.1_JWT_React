using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("SystemType", Schema = "dbo")]
    public partial class SystemTypeEntity
    {
        public SystemTypeEntity()
        {
            VersionHistory = new HashSet<VersionHistoryEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VersionHistoryEntity> VersionHistory { get; set; }
    }
}
