using bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "You have to enter your name")]
        [Display(Name = "Name")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "You have to enter a email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

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
