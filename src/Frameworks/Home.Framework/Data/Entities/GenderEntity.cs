using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Gender", Schema = "dbo")]
    public partial class GenderEntity
    {
        public GenderEntity()
        {
            Employee = new HashSet<EmployeeEntity>();
        }

        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeEntity> Employee { get; set; }
    }
}
