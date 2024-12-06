using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
