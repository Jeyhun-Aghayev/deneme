using Microsoft.AspNetCore.Identity;

namespace hacaton.Models.Account
{
	public class AppUser 
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public bool RememberMe { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
