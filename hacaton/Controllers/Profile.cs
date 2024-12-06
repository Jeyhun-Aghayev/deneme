using hacaton.DataAccess;
using hacaton.Helpers.Extensions;
using hacaton.Models;
using hacaton.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hacaton.Controllers
{
    public class Profile : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;

        public Profile(AppDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Employees employee = await _context.employess.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();
            GetEmplooyeProfileVM profileVM = new()
            {
                Name = employee.Name,
                Salary = employee.Salary,
                Bonus = employee.Bonus,
                Department = _context.departments.Where(d => d.Id == employee.Id).FirstOrDefault().Name

            };
            return View(profileVM);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Employees employee = await _context.employess.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();

            UpdateProfileVM profileVM = new()
            {
                Name = employee.Name,
                Email = employee.Email,
                Paswword = employee.Paswword,
                Image = employee.Image,
            };
            return View(profileVM);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateProfileVM profileVM)
        {
            if (id == null || id < 1) return BadRequest();
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
            employee.Paswword = profileVM.Paswword;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
