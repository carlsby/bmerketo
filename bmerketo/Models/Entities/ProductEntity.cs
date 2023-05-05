using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ProductImg { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsNew { get; set; }
    public bool? IsPopular { get; set; }
    public bool? IsFeatured { get; set; }
    public bool? IsOnSale { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

    public static implicit operator ProductModel(ProductEntity? entity)
    {
        return new ProductModel
        {
            Id = entity?.Id,
            Name = entity?.Name,
            ProductImg = entity?.ProductImg,
            Price = entity?.Price,
            Description = entity?.Description,
            IsNew = entity?.IsNew,
            IsPopular = entity?.IsPopular,
            IsFeatured = entity?.IsFeatured,
            IsOnSale = entity?.IsOnSale,
            Category = entity!.Category
        };
    }
}
