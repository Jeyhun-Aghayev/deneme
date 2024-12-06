using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class Employees : IdentityUser
	{
		public string Name { get; set; }
        public string Surname { get; set; }
        public bool RememberMe { get; set; }
		public int? DepartmentId { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public double Bonus { get; set; }
        public Attendance? Attendance { get; set; }
        public List<VacationRequest>? VacationRequests { get; set; }
        public List<Payroll>? Payrolls { get; set; }
        public List<Attendance>? attendances { get; set; }
        public List<Contracts>? contracts { get; set; }
        public Department? Department { get; set; }


    }
}
