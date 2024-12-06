using System.ComponentModel.DataAnnotations;

namespace hacaton.Models
{
	public class Attendance : BaseEntity
	{
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public DateTime Date { get; set; }= DateTime.Now;
        [Required]
        public DateTime StartTime { get; set; }
            [Required]
        public DateTime EndTime { get; set; }
            [Required]
        public int VacationLimit { get; set; }
        [Required]
        public int TotalHours { get; set; }
        public int? OverTimeHours { get; set; }

    }
}
