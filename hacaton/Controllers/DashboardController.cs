using hacaton.DataAccess;
using hacaton.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hacaton.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDBContext _context;

        public DashboardController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<GetDashboardVM> dashboardVMs = await _context.employess.Select(x =>
                new GetDashboardVM()
                {
                    Name = x.Name,
                    Salary = x.Salary,
                    Surname = x.Surname,
                    Bonus = x.Bonus,
                    Image = x.Image,
                }
                ).ToListAsync();
            return View(dashboardVMs);
        }
    }
}
