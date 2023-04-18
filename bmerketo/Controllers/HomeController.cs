using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace mvc_app_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new CollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                    GridItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel {Id = "1", ProductTitle="Apple watch series 4", Price = 329, ImageUrl = "images/product-images/applewatch.png"},
                        new GridCollectionItemViewModel {Id = "2", ProductTitle="Dress", Price = 40, ImageUrl = "images/product-images/dress.jpg"},
                        new GridCollectionItemViewModel {Id = "3", ProductTitle="Laptop", Price = 499, ImageUrl = "images/product-images/laptop.jpg"},
                        new GridCollectionItemViewModel {Id = "4", ProductTitle="Standing Lamp", Price = 50, ImageUrl = "images/product-images/standinglamp.jpg"},
                        new GridCollectionItemViewModel {Id = "5", ProductTitle="Soap collection", Price = 25, ImageUrl = "images/product-images/soap.jpg"},
                        new GridCollectionItemViewModel {Id = "6", ProductTitle="Suit", Price = 159, ImageUrl = "images/product-images/suit.jpg"},
                        new GridCollectionItemViewModel {Id = "7", ProductTitle="Shoes", Price = 65, ImageUrl = "images/product-images/shoes.jpg"},
                        new GridCollectionItemViewModel {Id = "8", ProductTitle="Iphone 13 64GB", Price = 699, ImageUrl = "images/product-images/iphone13.jpg"},
                    }
                },
                Sales = new SalesViewModel
                {
                    SalesItems = new List<SalesProductViewModel>
                    {
                        new SalesProductViewModel {Id = "1", ImageUrl ="images/sales-images/sales_laptop.png", ProductName = "Laptop", Price = 40, DiscountPrice = 60},
                        new SalesProductViewModel {Id = "2", ImageUrl ="images/sales-images/sales_speaker.png", ProductName = "Speaker", Price = 30, DiscountPrice = 50},
                    }
                },
            };

            return View(viewModel);
        }
    }
}
