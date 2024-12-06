using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class VacationRequest : BaseEntity
	{
        public string? EmployeeId { get; set; }
		public Employees? Employee { get; set; } 
       
		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; } 

		public string Status { get; set; } = "Pending"; 
		public string? AdminResponse { get; set; }
	}
}