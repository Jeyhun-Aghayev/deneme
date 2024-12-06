using System.Diagnostics.Contracts;
using hacaton.DataAccess;
using hacaton.Models;
using hacaton.ViewModels.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
    [Area("Manage")]
	//[Authorize(Roles = "Admin")]

	public class ContractController(AppDBContext _context) : Controller
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
        public async Task<IActionResult> Create(ContractCreateVM vm)
        {
            if (!ModelState.IsValid) { return View(); }
            Contracts contract = new Contracts()
            {
                EmployeeId = vm.EmployeeId,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                BonusPercentage = vm.BonusPercentage,
                Email = vm.Email,
                HorkyRate = vm.HorkyRate,
                MonthlyMaxHours = vm.MonthlyMaxHours,
            };
            await _context.contracts.AddAsync(contract);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var data = await _context.contracts.FindAsync(id);
            if (data == null) { return NotFound(); }
            data.IsDeleted = true;
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var data = await _context.contracts.FindAsync(id);
            if (data == null) { return BadRequest(); }
            Contracts contract = new Contracts()
            {
				EmployeeId = data.EmployeeId,
				StartDate = data.StartDate,
				EndDate = data.EndDate,
				BonusPercentage = data.BonusPercentage,
				Email = data.Email,
				HorkyRate = data.HorkyRate,
				MonthlyMaxHours = data.MonthlyMaxHours,
			};
            return View(contract);


        }
        [HttpPost]
		public async Task<IActionResult> Update(ContractUpdateVM vm , int? id)
		{
            if (!id.HasValue) { return BadRequest(); }
            var data = await _context.contracts.FindAsync(id);
            if (data == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return View(); }
            data.StartDate=vm.StartDate;
            data.EndDate=vm.EndDate;
            data.BonusPercentage=vm.BonusPercentage;
            data.Email=vm.Email;
            data.MonthlyMaxHours=vm.MonthlyMaxHours;
            data.EmployeeId=vm.EmployeeId;
            data.HorkyRate=vm.HorkyRate;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


		}

	}
}
