using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Company", Schema = "dbo")]
    public partial class CompanyEntity
    {
        public CompanyEntity()
        {
            Department = new HashSet<DepartmentEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string OrganizationNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<DepartmentEntity> Department { get; set; }
    }
}
