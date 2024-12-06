using hacaton.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace hacaton.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDBContext _context;

        public DashboardController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
