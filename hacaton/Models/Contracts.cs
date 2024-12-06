using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class Contracts : BaseEntity
	{

		[Required]
		public string EmployeeId { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
			[Required]
		public DateTime EndDate { get; set; }
		[Required]
		public Decimal HorkyRate { get; set; }
	    [Required]
		public int MonthlyMaxHours { get; set; }
		public double? BonusPercentage { get; set; }
		

	}
}
