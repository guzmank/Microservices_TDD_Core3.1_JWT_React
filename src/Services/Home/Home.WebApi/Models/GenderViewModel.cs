using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class GenderViewModel
    {
        public GenderViewModel()
        {
            Employee = new HashSet<EmployeeViewModel>();
        }

        public int UniqueId { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<EmployeeViewModel> Employee { get; set; }
    }
}
