using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.HealthStatuses;

public interface IHealthStatusQueryRepository
{
    IQueryable<HealthStatus> GetAll();
}
