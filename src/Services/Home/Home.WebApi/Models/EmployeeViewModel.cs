using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployeeViewModel>();
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

        public virtual GenderViewModel GenderUnique { get; set; }
        public virtual LanguageViewModel LanguageUnique { get; set; }
        public virtual SiteStyleTypeViewModel SiteStyleTypeUnique { get; set; }
        public virtual UserViewModel UserUnique { get; set; }
        public virtual ICollection<DepartmentEmployeeViewModel> DepartmentEmployee { get; set; }
    }
}
