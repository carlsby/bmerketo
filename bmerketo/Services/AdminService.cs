using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace bmerketo.Services
{
    public class AdminService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
