﻿namespace bmerketo.ViewModels;

public class GridCollectionItemViewModel
{
    public string Id { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string ProductTitle { get; set; } = null!;
    public decimal Price { get; set; }
}
