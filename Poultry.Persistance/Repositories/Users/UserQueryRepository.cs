using Microsoft.AspNetCore.Identity;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.Users;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.Users;

public class UserQueryRepository : IUserQueryRepository, IScopedLifetime
{
    private readonly UserManager<AppUser> _userManager;

    public UserQueryRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AppUser> GetByName(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }
}
