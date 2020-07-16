using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class SystemTypeViewModel
    {
        public SystemTypeViewModel()
        {
            VersionHistory = new HashSet<VersionHistoryViewModel>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<VersionHistoryViewModel> VersionHistory { get; set; }
    }
}
