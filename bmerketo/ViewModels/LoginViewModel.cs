using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "You have to enter a email address")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You have to enter a password")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;
}
