using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployeeDto>();
        }

        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Mobil { get; set; }
        public int GenderUniqueId { get; set; }
        public Guid UserUniqueId { get; set; }
        public Guid LanguageUniqueId { get; set; }
        public int SiteStyleTypeUniqueId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual GenderDto GenderUnique { get; set; }
        public virtual LanguageDto LanguageUnique { get; set; }
        public virtual SiteStyleTypeDto SiteStyleTypeUnique { get; set; }
        public virtual UserDto UserUnique { get; set; }
        public virtual ICollection<DepartmentEmployeeDto> DepartmentEmployee { get; set; }
    }
}
