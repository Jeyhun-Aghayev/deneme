using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class Employees : IdentityUser
	{
		public string Name { get; set; }
        public string Surname { get; set; }
        public bool RememberMe { get; set; }
		public int DepartmentId { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public double Bonus { get; set; }
        public Attendance? Attendance { get; set; }
        public IEnumerable<VacationRequest>? VacationRequests { get; set; }
        public IEnumerable<Payroll>? Payrolls { get; set; }
        public IEnumerable<Attendance>? attendances { get; set; }
        public IEnumerable<Contracts>? contracts { get; set; }
        public Department Department { get; set; }


    }
}
