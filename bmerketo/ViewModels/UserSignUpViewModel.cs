using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using bmerketo.Models.Entities;

namespace bmerketo.ViewModels;

public class UserSignUpViewModel
{
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The first name can only contain letters")]
    public string FirstName { get; set; } = null!;

    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The last name can only contain letters")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You need to provide an e-mail adress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$", ErrorMessage = "Invalid e-mail format")]
    public string Email { get; set; } = null!;

    [RegularExpression("^[0-9]{10}$", ErrorMessage = "The phone number should be exactly 10 digits")]
    public string? PhoneNumber { get; set; }

    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "The password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, and one digit")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    public string? StreetName { get; set; }

    [RegularExpression("^[0-9]{6}$", ErrorMessage = "The postal code should be exactly 6 digits")]
    public string? PostalCode { get; set; }

    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The city name can only contain letters")]
    public string? City { get; set; }
    public string? ProfileImg { get; set; }


    public static implicit operator IdentityUser(UserSignUpViewModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }

    public static implicit operator UserProfileEntity(UserSignUpViewModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            ProfileImg = model.ProfileImg
        };
    }

    public static implicit operator UserAddressEntity(UserSignUpViewModel model)
    {
        return new UserAddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City
        };
    }
}
