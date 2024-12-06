using Microsoft.AspNetCore.Mvc;

namespace hacaton.Controllers
{
    public class Profile : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
