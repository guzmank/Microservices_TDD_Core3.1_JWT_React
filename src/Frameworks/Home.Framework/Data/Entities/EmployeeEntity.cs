using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Employee", Schema = "dbo")]
    public partial class EmployeeEntity
    {
        public EmployeeEntity()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployeeEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Mobil { get; set; }
        [ForeignKey("GenderUniqueId")]
        public int GenderUniqueId { get; set; }
        [ForeignKey("UserUniqueId")]
        public Guid UserUniqueId { get; set; }
        [ForeignKey("LanguageUniqueId")]
        public Guid LanguageUniqueId { get; set; }
        [ForeignKey("SiteStyleTypeUniqueId")]
        public int SiteStyleTypeUniqueId { get; set; }

        public virtual GenderEntity GenderUnique { get; set; }
        public virtual LanguageEntity LanguageUnique { get; set; }
        public virtual SiteStyleTypeEntity SiteStyleTypeUnique { get; set; }
        public virtual UserEntity UserUnique { get; set; }
        public virtual ICollection<DepartmentEmployeeEntity> DepartmentEmployee { get; set; }
    }
}
