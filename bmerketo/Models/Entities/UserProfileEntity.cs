using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using bmerketo.ViewModels;

namespace bmerketo.Models.Entities
{
    public class UserProfileEntity
    {
        [Key, ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfileImg { get; set; }

        public IdentityUser User { get; set; } = null!;

        public int AddressId { get; set; }
        public UserAddressEntity Address { get; set; } = null!;

        public static implicit operator UserViewModel(UserProfileEntity model)
        {
            return new UserViewModel
            {
                FirstName = model.FirstName!,
                LastName = model.LastName!,
                ProfileImg = model.ProfileImg,
            };
        }
    }
}
