using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
	public class EmployeeManagementController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
