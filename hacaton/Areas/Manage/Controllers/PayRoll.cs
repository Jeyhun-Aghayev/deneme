using Microsoft.AspNetCore.Mvc;

namespace hacaton.Areas.Manage.Controllers
{
	public class PayRoll : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
