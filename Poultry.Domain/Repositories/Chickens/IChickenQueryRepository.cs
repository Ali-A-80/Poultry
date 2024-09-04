using Microsoft.EntityFrameworkCore.Query;
using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.Chickens;

public interface IChickenQueryRepository
{
    IIncludableQueryable<Chicken, HealthStatus> GetAll(CancellationToken cancellationToken);
}
