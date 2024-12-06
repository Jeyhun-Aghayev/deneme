using System.ComponentModel.DataAnnotations;
using hacaton.Helpers;

namespace hacaton.Models
{
	public class Payroll:BaseEntity
	{
		[Required]
        public string EmployeeId { get; set; }
		public Employees? employees { get; set; }
		[Required]
		public decimal Salary { get; set; }
		public double? Bonus { get; set; }
		[Required]
		public int Deductions { get; set; }
		[Required]

        public string Status { get; set; }
			[Required]
        public Months months { get; set; }
		[Required]
		public DateTime year { get; set; }	


    }
}
