using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("SiteStyleType", Schema = "dbo")]
    public partial class SiteStyleTypeEntity
    {
        public SiteStyleTypeEntity()
        {
            Employee = new HashSet<EmployeeEntity>();
        }

        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeEntity> Employee { get; set; }
    }
}
