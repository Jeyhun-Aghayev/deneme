using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
<<<<<<< HEAD
    public class VacationRequest : BaseEntity
    {
        public int EmployeeId { get; set; }


        public Employees employees { get; set; }


        [Required]
=======
	public class VacationRequest : BaseEntity
	{
<<<<<<< HEAD
        public string? EmployeeId { get; set; }
		public Employees? Employee { get; set; } 
       
		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; } 

		public string Status { get; set; } = "Pending"; 
		public string? AdminResponse { get; set; }
	}
=======

        public Employees employees { get; set; }
        public int EmployeeId { get; set; }
       



		[Required]
>>>>>>> 44211f934434728d96015a46f7f981ba5793947f

        public DateTime StartDate { get; set; } // İcazə başlama tarixi

        [Required]
        public DateTime EndDate { get; set; } // İcazə bitmə tarixi

        public string Status { get; set; } = "Pending"; // Təsdiqlənmə vəziyyəti (Pending, Approved, Rejected)

        public string? AdminResponse { get; set; } // Admin cavabı (İstəyə bağlı)

        public Employees Employee { get; set; } // Əlaqəli işçi (navigasiya xüsusiyyəti)
    }
>>>>>>> 78df81cbbfd46b772a2f7b571aff3d9020688cb7
}