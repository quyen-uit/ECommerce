﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClamsPrincipleWithAddress(this UserManager<AppUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }
        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
