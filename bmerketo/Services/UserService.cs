using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace bmerketo.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
    {
        var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
        return userProfileEntity!;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllProfilesAsync()
    {
        var userRoles = new List<UserViewModel>();

        var Users = await _userManager.Users.ToListAsync();

        foreach (var user in Users)
        {
            List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);

            var userProfile = await GetUserProfileAsync(user.Id);

            var profileWithRole = new UserViewModel
            {
                Id = userProfile.UserId,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfileImg = userProfile.ProfileImg,
                UserRoles = roles[0]
            };
            userRoles.Add(profileWithRole);
        }

        return userRoles;
    }

    public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
    {
        var roles = new List<RoleViewModel>();
        var identityRoles = await _identityContext.Roles.ToListAsync();

        foreach (var role in identityRoles)
        {
            roles.Add(new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!
            });
        }

        return roles;
    }

    public async Task<UserViewModel> GetCurrentUserAsync(ClaimsPrincipal claim)
    {
        try
        {
            UserViewModel userViewModel = new();

            var user = await _userManager.FindByEmailAsync(claim.Identity!.Name!);

            if (user != null)
            {
                var profile = await GetAsync(x => x.UserId == user.Id);

                userViewModel = profile;
                userViewModel.Email = user.UserName;
                userViewModel.PhoneNumber = user.PhoneNumber;
            }
            return userViewModel;
        }
        catch { return null!; }
    }

    public async Task<UserProfileEntity> GetAsync(Expression<Func<UserProfileEntity, bool>> predicate)
    {
        var userProfile = await _identityContext.UserProfiles.FirstOrDefaultAsync(predicate);

        return userProfile!;
    }
}
