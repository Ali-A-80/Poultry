using Microsoft.AspNetCore.Identity;
using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.Users;

public interface IUserCommandRepository
{
    Task<IdentityResult> AddUser(AppUser user , string password);

    Task<IdentityResult> UpdateUser(AppUser user);

    Task<AppUser> GetByName(string userName);
}
