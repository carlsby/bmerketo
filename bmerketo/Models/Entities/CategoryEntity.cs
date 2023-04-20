namespace bmerketo.Models.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; } = null!;

        public ICollection<ProductEntity> Products = new HashSet<ProductEntity>();

        public static implicit operator CategoryModel(CategoryEntity entity)
        {
            return new CategoryModel
            {
                Id = entity?.Id,
                CategoryTitle = entity?.CategoryTitle,
            };
        }
    }
}
