using bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "You have to enter your name")]
        [RegularExpression("^[a-zA-Z0-9][a-zA-Z0-9\\s'-]{0,98}[a-zA-Z0-9]$\r\n")]
        [Display(Name = "Name")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "You have to enter a email address")]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$\r\n")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[\\d+\\s()-]{8,20}$\r\n")]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company")]
        [RegularExpression("/^[\\s\\S]{0,100}$/")]
        public string? Company { get; set; }

        [Display(Name = "Comment")]
        [RegularExpression("/^[\\s\\S]{0,500}$/")]
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
