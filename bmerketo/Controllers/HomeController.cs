﻿using bmerketo.Models;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace mvc_app_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public HomeController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string category)
        {
            ViewData["Title"] = "Home";

            List<ProductModel> products;
            List<CategoryModel> categories;

            products = (List<ProductModel>)await _productService.GetSearchToList(category);
            categories = (List<CategoryModel>)await _categoryService.GetAllCategoriesAsync();

            ViewData["Categories"] = categories;


            return View(products);
        }
    }
}
