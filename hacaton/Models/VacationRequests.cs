using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class VacationRequest : BaseEntity
	{
        public Employees employees { get; set; }
        public int EmployeeId { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		[Required]
        public string Status { get; set; }
	   [Required]
        public string Reason { get; set; }
    }
}
