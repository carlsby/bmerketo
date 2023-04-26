using bmerketo.Models;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace mvc_app_1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contact;

        public ContactsController(ContactService contact)
        {
            _contact = contact;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contact";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _contact.CommentAsync(model))
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Something went wrong.");
            }

            return View(model);
        }

    }
}
