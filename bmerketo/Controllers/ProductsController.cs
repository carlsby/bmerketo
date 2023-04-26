using bmerketo.Migrations;
using bmerketo.Models;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmkerketo.Controllers
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

        public async Task<IActionResult> Product(int id)
        {
            ViewData["Title"] = "Product " + id;
            ProductModel model = await _productService.GetSpecificProductAsync(id);

            return View(model);
        }
    }
}
