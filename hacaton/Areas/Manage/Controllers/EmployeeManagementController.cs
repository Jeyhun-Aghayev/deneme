using hacaton.Helpers;
using hacaton.Models.Account;
using hacaton.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
	public class EmployeeManagementController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public EmployeeManagementController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		//public IActionResult Update(){ }
		//public IActionResult Delete() { }

		[HttpPost]
		public async Task<IActionResult> Create(RegisterVm registerVm)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			AppUser user = new AppUser()
			{
				Name = registerVm.Name,
				Email = registerVm.Email,
				Surname = registerVm.Surname,
				UserName = registerVm.Username,
				DepartmentId = registerVm.DepartmentId,
			};
			var result = await _userManager.CreateAsync(user, registerVm.Password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}

			await _userManager.AddToRoleAsync(user, UserRole.Employee.ToString());
			return RedirectToAction(nameof(Index), "home");
		}
	}
}
