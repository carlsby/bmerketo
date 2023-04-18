using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models;

public class ProductModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? ProductImg { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
