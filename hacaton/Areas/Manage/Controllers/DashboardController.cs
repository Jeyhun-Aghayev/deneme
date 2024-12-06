using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
