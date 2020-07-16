using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Language", Schema = "dbo")]
    public partial class LanguageEntity
    {
        public LanguageEntity()
        {
            Employee = new HashSet<EmployeeEntity>();
            VersionHistory = new HashSet<VersionHistoryEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeEntity> Employee { get; set; }
        public virtual ICollection<VersionHistoryEntity> VersionHistory { get; set; }
    }
}
