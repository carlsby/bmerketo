using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ProductImg { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountPrice { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

        public static implicit operator ProductModel(ProductEntity? entity)
        {
            return new ProductModel
            {
                Id = entity?.Id,
                Name = entity?.Name,
                ProductImg = entity?.ProductImg,
                Price = entity?.Price,
                DiscountPrice = entity?.DiscountPrice,
                Description = entity?.Description,
                Category = entity?.Category!,
            };
        }
    }
}
