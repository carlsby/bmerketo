using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.ViewModels;

public class ProductRegistrationViewModel
{
    [Required(ErrorMessage = "You have to enter a product name")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "You have to enter a image link")]
    [Display(Name = "Image URL *")]
    public string ImageUrl { get; set; } = null!;

    [Required(ErrorMessage = "You have to choose a category")]
    [Display(Name = "Category *")]
    public int CategoryId { get; set; }

    [Display(Name = "Product description (Optional)")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "You have to enter a product price")]
    [Display(Name = "Product price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }


    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        return new ProductEntity
        {
            Name = productRegistrationViewModel.Name,
            ProductImg = productRegistrationViewModel.ImageUrl,
            Description = productRegistrationViewModel.Description,
            Price = productRegistrationViewModel.Price,
            CategoryId = productRegistrationViewModel.CategoryId
        };
    }
}
