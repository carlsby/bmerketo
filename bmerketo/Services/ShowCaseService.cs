using bmerketo.Models;

namespace bmerketo.Services;

public class ShowCaseService
{
    private readonly List<ShowCaseModel> _showCases = new()
    {
        new ShowCaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection.",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products"
            }
        },

        new ShowCaseModel()
        {
            Ingress = "BMKERKETO THE BEST A PERSON CAN GET",
            Title = "Now with all new spices",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products"
            }
        }
    };


    public ShowCaseModel GetLatest()
    {
        return _showCases.LastOrDefault()!;
    }
}
