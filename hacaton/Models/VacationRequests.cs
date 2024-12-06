using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class VacationRequest : BaseEntity
	{
<<<<<<< HEAD
        public Employees employees { get; set; }
        public int EmployeeId { get; set; }
       
=======

        public Employees employees { get; set; }
        public string EmployeeId { get; set; }


>>>>>>> 8a1181f47fdaf642749dbedd89a864944837b6c3
		[Required]

		public DateTime StartDate { get; set; } // İcazə başlama tarixi

		[Required]
		public DateTime EndDate { get; set; } // İcazə bitmə tarixi

		public string Status { get; set; } = "Pending"; // Təsdiqlənmə vəziyyəti (Pending, Approved, Rejected)

		public string? AdminResponse { get; set; } // Admin cavabı (İstəyə bağlı)

		public Employees Employee { get; set; } // Əlaqəli işçi (navigasiya xüsusiyyəti)
	}
}