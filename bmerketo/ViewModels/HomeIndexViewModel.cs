namespace bmerketo.ViewModels
{
    public class HomeIndexViewModel
    {
        public string ViewTitle { get; set; } = "Home";
        public CollectionViewModel BestCollection { get; set; } = null!;
        public SalesViewModel Sales { get; set; } = null!;
    }
}
