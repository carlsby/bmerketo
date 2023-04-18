using bmerketo.Migrations;
using bmerketo.Models;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace mvc_app_1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string category)
        {
            ViewData["Title"] = "Products";

            List<ProductModel> products;
            List<CategoryModel> categories;

            products = (List<ProductModel>)await _productService.GetSearchToList(category);
            categories = (List<CategoryModel>)await _categoryService.GetAllCategoriesAsync();

            ViewData["Categories"] = categories;


            return View(products);
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for products";
            return View();
        }

        public IActionResult Product()
        {
            ViewData["Title"] = "Specific Product";
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
    }
}
