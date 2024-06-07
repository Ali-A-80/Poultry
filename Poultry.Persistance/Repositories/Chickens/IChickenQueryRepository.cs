using Microsoft.EntityFrameworkCore.Query;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.Chickens;

public interface IChickenQueryRepository
{
    IIncludableQueryable<Chicken, HealthStatus> GetChickenList(CancellationToken cancellationToken);
}
