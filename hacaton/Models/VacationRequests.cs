using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class VacationRequest : BaseEntity
	{

        public Employees employees { get; set; }
        public string EmployeeId { get; set; }


		[Required]

		public DateTime StartDate { get; set; } // İcazə başlama tarixi

		[Required]
		public DateTime EndDate { get; set; } // İcazə bitmə tarixi

		public string Status { get; set; } = "Pending"; // Təsdiqlənmə vəziyyəti (Pending, Approved, Rejected)

		public string? AdminResponse { get; set; } // Admin cavabı (İstəyə bağlı)

		public Employees Employee { get; set; } // Əlaqəli işçi (navigasiya xüsusiyyəti)
	}
}