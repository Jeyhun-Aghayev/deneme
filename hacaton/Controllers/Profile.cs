using hacaton.DataAccess;
using hacaton.Models;
using hacaton.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hacaton.Controllers
{
    public class Profile : Controller
    {
        private readonly AppDBContext _context;

        public Profile(AppDBContext context)
        {
            _context = context;
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
            return View(profileVM);

        }
    }
}
