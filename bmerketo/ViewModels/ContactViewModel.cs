using bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "You have to enter your name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)$", ErrorMessage = "You have to enter a valid name")]
        [Display(Name = "Name")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "You have to enter a email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$", ErrorMessage = "You have to enter a valid email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "You have to enter a message")]
        [Display(Name = "Comment")]
        public string Comment { get; set; } = null!;

        public static implicit operator ContactEntity(ContactViewModel contactViewModel)
        {
            return new ContactEntity
            {
                FullName = contactViewModel.FullName,
                Email = contactViewModel.Email,
                PhoneNumber = contactViewModel.PhoneNumber,
                Company = contactViewModel.Company,
            };
        }

        public static implicit operator CommentEntity(ContactViewModel contactViewModel)
        {
            return new CommentEntity
            {
                Comment = contactViewModel.Comment,
                CommentCreated = DateTime.Now
            };
        }
    }
}
