using bmerketo.Contexts;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IdentityContext _identityContext;
        private readonly SeedService _seedService;

        public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = userManager;
            _identityContext = identityContext;
            _signInManager = signInManager;
            _seedService = seedService;
            _rolemanager = rolemanager;
        }

        public async Task<bool> SignUpAsync(UserSignUpViewModel model)
        {
            try
            {
                await _seedService.SeedRoles();

                var roleName = "user";

                if (!await _userManager.Users.AnyAsync())
                {
                    roleName = "admin";
                }

                // Create a new IdentityUser object and set its properties
                IdentityUser identityUser = model;

                // Create the user in the database
                await _userManager.CreateAsync(identityUser, model.Password);

                // Add the user to the specified role
                await _userManager.AddToRoleAsync(identityUser, roleName);

                // Create a new AddressEntity object and set its properties with the address details from the UserSignUpViewModel
                UserAddressEntity addressEntity = new UserAddressEntity
                {
                    StreetName = model.StreetName,
                    PostalCode = model.PostalCode,
                    City = model.City
                };

                // Create a new UserProfileEntity object and set its properties
                UserProfileEntity userProfileEntity = new UserProfileEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ProfileImg = model.ProfileImg,
                    Address = addressEntity, // set the Address property to the newly created AddressEntity
                    UserId = identityUser.Id
                };

                // Add the UserProfileEntity to the context and save the changes
                _identityContext.UserProfiles.Add(userProfileEntity);
                await _identityContext.SaveChangesAsync();

                return true;
            }
            catch { return false; }
        }

        public async Task<bool> SignInAsync(UserSignInViewModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                return result.Succeeded;
            }
            catch { return false; }
        }


        public async Task<bool> SignOutAsync(ClaimsPrincipal user)
        {
            await _signInManager.SignOutAsync();

            return _signInManager.IsSignedIn(user);
        }
    }
}
