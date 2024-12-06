using hacaton.Areas.Manage.Controllers;
using hacaton.DataAccess;
using hacaton.Helpers;
using hacaton.Models;
using hacaton.Models.Account;
using hacaton.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hacaton.Controllers
{
    public class AccountController: Controller
    {
        AppDBContext db;
        private readonly UserManager<Employees> _userManager;
        private readonly SignInManager<Employees> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<Employees> userManager, SignInManager<Employees> signInManager, RoleManager<IdentityRole> roleManager, AppDBContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			this.db = db;
		}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Employees user = await _userManager.FindByNameAsync(loginVm.UsernameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(loginVm.UsernameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "Username/Email or Password yanlisdir ");
                    return View();
                }
            }
            var result = _signInManager.CheckPasswordSignInAsync(user, loginVm.Password, true).Result;
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(String.Empty, "Biraz sonra yeniden cehd edin");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Username/Email or Password yanlisdir");
                return View();
            }
            await _signInManager.SignInAsync(user, loginVm.RememberMe);
            
				if (User.IsInRole("Admin")) return RedirectToAction("index", "dashboard", new { area = "Manage" });
				if (User.IsInRole("Employee")) return RedirectToAction("index", "dashboard");
		
			/*if (ReturnUrl != null && !ReturnUrl.Contains("Login"))
            {
                return Redirect(ReturnUrl);
            }*/

			return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
            foreach (UserRole item in Enum.GetValues(typeof(UserRole)))
            {
                if (await _roleManager.FindByNameAsync(item.ToString()) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString(),
                    });
                }
            }

            return RedirectToAction(nameof(Index), "Home");
        }
        //public async Task<IActionResult> PayRoll(string? id)
        //{
        //    if (id == null) { return BadRequest(); }
        //    var data = db.payrolls.Find
            


        //}
    }
}
