using Microsoft.AspNetCore.Identity;

namespace hacaton.Models.Account
{
	public class AppUser : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public bool RememberMe { get; set; }
	}
}
