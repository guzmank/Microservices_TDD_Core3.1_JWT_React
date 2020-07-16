using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class LanguageDto
    {
        public LanguageDto()
        {
            Employee = new HashSet<EmployeeDto>();
            VersionHistory = new HashSet<VersionHistoryDto>();
        }

        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
        public virtual ICollection<VersionHistoryDto> VersionHistory { get; set; }
    }
}
