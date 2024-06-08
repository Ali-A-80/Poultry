using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.HealthStatuses;

public interface IHealthStatusQueryRepository
{
    IQueryable<HealthStatus> GetAll();
}
