﻿using Microsoft.AspNetCore.Identity;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.Users;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.Users;

public class UserCommandRepository : IUserCommandRepository, IScopedLifetime
{
    private readonly UserManager<AppUser> _userManager;

    public UserCommandRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> AddUser(AppUser user, string password)
    {
        ArgumentNullException.ThrowIfNull(nameof(user));

        return await _userManager.CreateAsync(user, password);
    }

    public async Task<AppUser> GetByName(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }

    public async Task<IdentityResult> UpdateUser(AppUser user)
    {
        var result = await _userManager.UpdateAsync(user);

        return result;
    }
}
