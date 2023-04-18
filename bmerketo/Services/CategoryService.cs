using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace bmerketo.Services
{
    public class CategoryService
    {

        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = new List<CategoryModel>();
            var items = await _context.Category.ToListAsync();
            foreach (var c in items)
            {
                categories.Add(new CategoryModel
                {
                    Id = c.Id,
                    CategoryTitle = c.CategoryTitle
                });
            }
            return categories;
        }
    }
}
