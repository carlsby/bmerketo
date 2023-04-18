using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
            ProductEntity productEntity = productRegistrationViewModel;

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetSearchToList(string name)
    {
        var products = new List<ProductModel>();

        if (string.IsNullOrEmpty(name))
        {
            foreach (var product in await _context.Products
                .OrderByDescending(p => p.Id)
                .ToListAsync())
            {
                products.Add(new ProductModel
                {
                    Id = product.Id,
                    ProductImg = product.ProductImg,
                    Name = product.Name,
                    Price = product.Price,
                });
            }
        }
        else
        {
            foreach (var product in await _context.Products
                .OrderByDescending(p => p.Id)
                .Where(x => x.Category.CategoryTitle == name)
                .ToListAsync())
            {
                products.Add(new ProductModel
                {
                    Id = product.Id,
                    ProductImg = product.ProductImg,
                    Name = product.Name,
                    Price = product.Price,
                });
            }
        }

        return products;
    }
}
