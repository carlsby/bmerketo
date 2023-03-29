using Microsoft.AspNetCore.Mvc;

namespace mvc_app_1.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact";
            return View();
        }
    }
}
