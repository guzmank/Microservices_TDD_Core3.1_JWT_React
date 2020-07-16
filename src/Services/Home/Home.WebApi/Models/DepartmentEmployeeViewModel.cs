using System;

namespace Home.WebApi.Models
{
    public class DepartmentEmployeeViewModel
    {
        public Guid UniqueId { get; set; }
        public Guid DepartmentUniqueId { get; set; }
        public Guid EmployeeUniqueId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual DepartmentViewModel DepartmentUnique { get; set; }
        public virtual EmployeeViewModel EmployeeUnique { get; set; }
    }
}
