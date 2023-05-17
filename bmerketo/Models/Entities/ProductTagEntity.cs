using bmerketo.Migrations.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(TagId))]
public class ProductTagEntity
{

    public int ProductId { get; set; }
    public ProductEntity? Product { get; set; }

    public int TagId { get; set; }
    public TagEntity? Tag { get; set; }
}
