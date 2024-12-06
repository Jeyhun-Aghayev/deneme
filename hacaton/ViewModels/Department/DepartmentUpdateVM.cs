using hacaton.Models;
using System.ComponentModel.DataAnnotations;

namespace hacaton.ViewModels.Department
{
    public class DepartmentUpdateVM
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<Employees> employees { get; set; }
    }
}
