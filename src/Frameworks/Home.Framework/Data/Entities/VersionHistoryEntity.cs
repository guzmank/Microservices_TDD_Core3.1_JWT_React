using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("VersionHistory", Schema = "dbo")]
    public partial class VersionHistoryEntity
    {
        [Key]
        public Guid UniqueId { get; set; }

        public string Title { get; set; }

        public string Number { get; set; }

        public DateTime Date { get; set; }

        public string Overview { get; set; }

        public string NewFunction { get; set; }

        public string EnhancedFunction { get; set; }

        public string FixedBug { get; set; }

        [ForeignKey("LanguageUniqueId")]
        public Guid LanguageUniqueId { get; set; }

        [ForeignKey("SystemTypeUniqueId")]
        public Guid SystemTypeUniqueId { get; set; }

        public virtual LanguageEntity LanguageUnique { get; set; }

        public virtual SystemTypeEntity SystemTypeUnique { get; set; }
    }
}
