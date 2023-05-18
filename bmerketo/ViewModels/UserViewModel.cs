using bmerketo.Migrations.Identity;
using bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfileImg { get; set; }
        public string? UserRoles { get; set; }
        public AddressViewModel? Address { get; set; }

        public static implicit operator UserProfileEntity(UserViewModel model)
        {
            return new UserProfileEntity
            {
                FirstName = model.FirstName!,
                LastName = model.LastName!,
                ProfileImg = model.ProfileImg,
            };
        }

        public static implicit operator IdentityUser(UserViewModel model)
        {
            return new IdentityUser
            {
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
        }
    }
}
