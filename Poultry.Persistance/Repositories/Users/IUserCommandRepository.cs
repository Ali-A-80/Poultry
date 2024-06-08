using Microsoft.AspNetCore.Identity;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.Users;

public interface IUserCommandRepository
{
    Task<IdentityResult> AddUser(AppUser user , string password);

    Task<IdentityResult> UpdateUser(AppUser user , string password);

    Task<AppUser> GetByName(string userName);
}
