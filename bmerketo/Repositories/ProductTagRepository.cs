using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories
{
    public class ProductTagRepository : Repo<ProductTagEntity>
    {
        public ProductTagRepository(DataContext context) : base(context)
        {
        }
    }
}
