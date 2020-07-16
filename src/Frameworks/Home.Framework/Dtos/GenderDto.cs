using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class GenderDto
    {
        public GenderDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public int UniqueId { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
    }
}
