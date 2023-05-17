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
        #region constructors and private fields
        private readonly ProductService _productService;
        private readonly AuthService _auth;
        private readonly AdminService _adminService;
        private readonly UserService _userService;
        private readonly TagService _tagService;

        public AdminController(ProductService productService, AdminService adminService, UserService userService, AuthService auth, TagService tagService)
        {
            _productService = productService;
            _adminService = adminService;
            _userService = userService;
            _auth = auth;
            _tagService = tagService;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Tags = await _tagService.GetTagsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel, string[] tags)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateAsync(productRegistrationViewModel);
                await _productService.AddProductTagsAsync(productRegistrationViewModel, tags);
                return RedirectToAction("Index", "Products");
            }
            //else
            //{
            //    ModelState.AddModelError("", "Something went wrong when trying to create a product");
            //}

            ViewBag.Tags = await _tagService.GetTagsAsync(tags);
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
