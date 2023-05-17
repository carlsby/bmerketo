using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly ProductTagRepository _productTagRepo;

    public ProductService(DataContext context, ProductTagRepository productTagRepo)
    {
        _context = context;
        _productTagRepo = productTagRepo;
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

    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == entity.Name);

        foreach (var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ProductId = product!.Id,
                TagId = int.Parse(tag)
            });
        }
    }

    public async Task<List<ProductEntity>> GetTagAsync(string tag)
    {
        var products = await _context.Products
            .Where(p => p.ProductTags.Any(t => t.Tag!.TagTitle == tag))
            .ToListAsync();

        return products;
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
                .Where(x => x.Category!.CategoryTitle == name)
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

    public async Task<ProductModel> GetSpecificProductAsync(string name)
    {
        ProductModel products = new ProductModel();
        products = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(x => x.Name == name);
        return products!;
    }
}
