using hacaton.DataAccess;
using hacaton.Helpers.Extensions;
using hacaton.Models;
using hacaton.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hacaton.Controllers
{
    public class Profile : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<Employees> _userManager;
        private readonly SignInManager<Employees> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public Profile(AppDBContext context, IWebHostEnvironment env, UserManager<Employees> userManager, SignInManager<Employees> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string? id)
        {
            if (id == null) return BadRequest();
            Employees employee = await _context.employess.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();
            GetEmplooyeProfileVM profileVM = new()
            {
                Name = employee.Name,
                Salary = employee.Salary,
                Bonus = employee.Bonus,
                Department = _context.departments.Where(d => d.Id == employee.DepartmentId).FirstOrDefault().Name

            };
            return View(profileVM);
        }
        public async Task<IActionResult> Update(string? id)
        {
            if (id == null) return BadRequest();
            Employees employee = await _context.employess.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();
            await _userManager.RemovePasswordAsync(employee);

            UpdateProfileVM profileVM = new()
            {
                Name = employee.Name,
                Email = employee.Email,
                Image = employee.Image,
            };
            return View(profileVM);

        }
        [HttpPost]
        public async Task<IActionResult> Update(string? id, UpdateProfileVM profileVM)
        {
            if (id == null) return BadRequest();
            Employees employee = await _context.employess.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();
            if (profileVM.Photo is not null)
            {
                if (!profileVM.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(profileVM.Photo), "Type is incorrect");
                    return View(profileVM);
                }
                if (!profileVM.Photo.CheckFileSize(Helpers.FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(profileVM.Photo), "Size must be less than 2MB");
                    return View(profileVM);
                }
                string fileName = await profileVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");
                employee.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                employee.Image = fileName;

            }
            employee.Email = profileVM.Email;
            employee.Name = profileVM.Name;
            employee.Password = profileVM.Paswword;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult JobDetail()
        {
            return View();
        }
    }
}
