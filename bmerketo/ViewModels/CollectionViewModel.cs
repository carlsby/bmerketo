﻿namespace bmerketo.ViewModels;

public class CollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
    public bool LoadMore { get; set; } = false;
}
