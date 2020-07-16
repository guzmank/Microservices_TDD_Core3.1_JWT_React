using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class SystemTypeDto
    {
        public SystemTypeDto()
        {
            VersionHistory = new HashSet<VersionHistoryDto>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<VersionHistoryDto> VersionHistory { get; set; }
    }
}
