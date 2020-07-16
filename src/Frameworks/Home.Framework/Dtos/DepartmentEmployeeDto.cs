using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class DepartmentEmployeeDto
    {
        public Guid UniqueId { get; set; }
        public Guid DepartmentUniqueId { get; set; }
        public Guid EmployeeUniqueId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual DepartmentDto DepartmentUnique { get; set; }
        public virtual EmployeeDto EmployeeUnique { get; set; }
    }
}
