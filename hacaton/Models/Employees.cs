using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
    public class Employees : BaseEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(64)]
        public string Email { get; set; } = null!;
        [Required, MaxLength(32)]
        public string Paswword { get; set; } = null!;
        public string DepartmentId { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public double Bonus { get; set; }
        public string Image { get; set; }
        public Attendance? Attendance { get; set; }
        public IEnumerable<VacationRequest>? VacationRequests { get; set; }
        public IEnumerable<Payroll>? Payrolls { get; set; }
        public IEnumerable<Attendance>? attendances { get; set; }
        public IEnumerable<Contracts>? contracts { get; set; }
        public Department Department { get; set; }


    }
}
