using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo.Services
{
    public class AdminService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityContext _identityContext;

        public AdminService(UserManager<IdentityUser> userManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            _identityContext = identityContext;
        }

        public async Task<bool> ChangeRoleAsync(UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id!);
            if (user != null)
            {
                var role = await _userManager.GetRolesAsync(user);

                foreach(var roleEntity in role)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleEntity);
                }

                await _userManager.AddToRoleAsync(user, model.UserRoles!);
                await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
