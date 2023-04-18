namespace bmerketo.ViewModels;

public class SalesProductViewModel
{
    public string? Id { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? Price { get; set; }
    public decimal? DiscountPrice { get; set; }
}
