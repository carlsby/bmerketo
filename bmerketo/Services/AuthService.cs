﻿using bmerketo.Contexts;
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

                IdentityUser identityUser = model;

                await _userManager.CreateAsync(identityUser, model.Password);

                await _userManager.AddToRoleAsync(identityUser, roleName);

                UserAddressEntity addressEntity = new UserAddressEntity
                {
                    StreetName = model.StreetName,
                    PostalCode = model.PostalCode,
                    City = model.City
                };

                UserProfileEntity userProfileEntity = new UserProfileEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ProfileImg = model.ProfileImg,
                    Address = addressEntity,
                    UserId = identityUser.Id
                };

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
