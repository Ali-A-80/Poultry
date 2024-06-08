using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.Users;

public interface IUserQueryRepository
{
    Task<AppUser> GetByName(string userName);
}
