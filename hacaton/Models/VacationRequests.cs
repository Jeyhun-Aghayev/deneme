using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class VacationRequest : BaseEntity
	{
<<<<<<< HEAD
        public Employees employees { get; set; }
        public int EmployeeId { get; set; }
=======
        //<<<<<<< HEAD
        public Employees employees { get; set; }
       
//=======
//>>>>>>> 0c32af58a61a48184a31888487ab5dca14d92974
>>>>>>> 3fc5d75921959dcaf176bf5bba12b47166d01261
		[Required]

		public DateTime StartDate { get; set; } // İcazə başlama tarixi

		[Required]
		public DateTime EndDate { get; set; } // İcazə bitmə tarixi

		public string Status { get; set; } = "Pending"; // Təsdiqlənmə vəziyyəti (Pending, Approved, Rejected)

		public string? AdminResponse { get; set; } // Admin cavabı (İstəyə bağlı)

		public Employees Employee { get; set; } // Əlaqəli işçi (navigasiya xüsusiyyəti)
	}
}