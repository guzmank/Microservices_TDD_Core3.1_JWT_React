using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("DepartmentEmployee", Schema = "dbo")]
    public partial class DepartmentEmployeeEntity
    {
        [Key]
        public Guid UniqueId { get; set; }
        [ForeignKey("DepartmentUniqueId")]
        public Guid DepartmentUniqueId { get; set; }
        [ForeignKey("EmployeeUniqueId")]
        public Guid EmployeeUniqueId { get; set; }

        public virtual DepartmentEntity DepartmentUnique { get; set; }
        public virtual EmployeeEntity EmployeeUnique { get; set; }
    }
}
