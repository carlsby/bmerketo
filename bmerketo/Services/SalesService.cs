using bmerketo.Models;

namespace bmerketo.Services;

public class SalesService
{
    private readonly List<SalesModel> _sales = new()
    {
        new SalesModel()
        {
            SellHeader = "FOR SALE",
            Discount = "50% OFF",
            SellFooter = "Get the best price",
            OfferText = "Get the best daily offer",
            ButtonText = "Discover more"
        },
    };


    public SalesModel GetLatest()
    {
        return _sales.LastOrDefault()!;
    }
}
