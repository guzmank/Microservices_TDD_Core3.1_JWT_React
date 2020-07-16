using System;

namespace Home.WebApi.Models
{
    public class VersionHistoryViewModel
    {
        public Guid UniqueId { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Overview { get; set; }
        public string NewFunction { get; set; }
        public string EnhancedFunction { get; set; }
        public string FixedBug { get; set; }
        public Guid LanguageUniqueId { get; set; }
        public Guid SystemTypeUniqueId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual LanguageViewModel LanguageUnique { get; set; }
        public virtual SystemTypeViewModel SystemTypeUnique { get; set; }
    }
}
