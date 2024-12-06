using hacaton.Helpers;
using hacaton.Models;
using hacaton.Models.Account;
using hacaton.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
	[Area("Manage")]
	//[Authorize(Roles = "Admin")]

	public class EmployeeManagementController : Controller
	{
		private readonly UserManager<Employees> _userManager;
		private readonly SignInManager<Employees> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public EmployeeManagementController(UserManager<Employees> userManager, SignInManager<Employees> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(RegisterVm registerVm)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			Employees user = new Employees()
			{
				Name = registerVm.Name,
				Email = registerVm.Email,
				Surname = registerVm.Surname,
				UserName = registerVm.Username,
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

			await _userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
			return RedirectToAction(nameof(Index), "Dashboard");
		}
	}
}
