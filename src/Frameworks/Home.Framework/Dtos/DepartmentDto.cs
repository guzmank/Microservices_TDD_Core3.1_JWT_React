using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class DepartmentDto
    {
        public DepartmentDto()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployeeDto>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public Guid CompanyUniqueId { get; set; }
        public bool Deleted { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual CompanyDto CompanyUnique { get; set; }
        public virtual ICollection<DepartmentEmployeeDto> DepartmentEmployee { get; set; }
    }
}
