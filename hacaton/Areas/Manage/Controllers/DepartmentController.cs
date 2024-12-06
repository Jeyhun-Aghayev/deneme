using hacaton.DataAccess;
using hacaton.Models;
using hacaton.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hacaton.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DepartmentController(AppDBContext _context) : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateVM vm)
        {
            if (vm.Name == null) { ModelState.AddModelError("Name", "Name must be fill"); }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(await _context.departments.AnyAsync(d=>d.Name==vm.Name)) {
                ModelState.AddModelError(nameof(vm.Name), "This name also exits");
            }
                Department department = new Department
                {
                    Name = vm.Name
                };

            await _context.departments.AddAsync(department);
           await _context.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id)
        {
            var data = await _context.departments.FindAsync(id);
            if (data is null) { return BadRequest(); }
            DepartmentUpdateVM vm = new DepartmentUpdateVM { Name = data.Name };
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if(!id.HasValue) { return BadRequest(); }
            var data = await _context.departments.FindAsync(id.Value);
            if(data is  null) { return NotFound(); }
           _context.Remove(data);   
            await _context .SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
