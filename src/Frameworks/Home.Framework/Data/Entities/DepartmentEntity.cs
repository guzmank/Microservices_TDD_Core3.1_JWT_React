using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Department", Schema = "dbo")]
    public partial class DepartmentEntity
    {
        public DepartmentEntity()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployeeEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        [ForeignKey("CompanyUniqueId")]
        public Guid CompanyUniqueId { get; set; }
        public bool Deleted { get; set; }

        public virtual CompanyEntity CompanyUnique { get; set; }
        public virtual ICollection<DepartmentEmployeeEntity> DepartmentEmployee { get; set; }
    }
}
