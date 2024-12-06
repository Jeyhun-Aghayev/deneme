using hacaton.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hacaton.Controllers
{
	public class PayRole(AppDBContext dBContext) : Controller
	{
		public async  Task<IActionResult> Index()
		{
			var data = await dBContext.payrolls.ToListAsync();
			return View(data);
		}
	}
}
