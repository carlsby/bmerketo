using Microsoft.AspNetCore.Mvc;

namespace mvc_app_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";

            return View();
        }
    }
}
