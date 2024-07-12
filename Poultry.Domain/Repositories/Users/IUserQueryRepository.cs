using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.Users;

public interface IUserQueryRepository
{
    Task<AppUser> GetByName(string userName);
}
