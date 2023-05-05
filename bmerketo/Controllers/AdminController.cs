using bmerketo.Models;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace bmerketo.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ProductService _productService;
        private readonly AuthService _auth;
        private readonly AdminService _adminService;
        private readonly UserService _userService;

        public AdminController(ProductService productService, AdminService adminService, UserService userService, AuthService auth)
        {
            _productService = productService;
            _adminService = adminService;
            _userService = userService;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.CreateAsync(productRegistrationViewModel))
                {
                    return RedirectToAction("Index", "Products");
                }

                ModelState.AddModelError("", "Something went wrong when trying to create a product");
            }

            return View();
        }

        public async Task<IActionResult> Users()
        {

            List<UserViewModel> users = (List<UserViewModel>)await _userService.GetAllProfilesAsync();
            users = users.OrderBy(u => u.UserRoles + u.LastName).ToList();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Users(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _adminService.ChangeRoleAsync(model))
                {
                    return RedirectToAction("Users");
                }

                ModelState.AddModelError("", "Something went wrong");
            }
            return View(model);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.SignUpAsync(model))
                {
                    return RedirectToAction("Users");
                }

                ModelState.AddModelError("", "A user with the same email already exits.");
            }

            return View(model);
        }
    }
}
