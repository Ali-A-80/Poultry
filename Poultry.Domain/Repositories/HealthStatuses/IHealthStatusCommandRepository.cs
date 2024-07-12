using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.HealthStatuses;

public interface IHealthStatusCommandRepository
{
    Task<bool> HealthStatusExists(long healthStatusId, CancellationToken cancellationToken);

    Task AddHealthStatus(HealthStatus entity, CancellationToken cancellationToken);

    Task UpdateHealthStatus(HealthStatus entity, CancellationToken cancellationToken);

    Task<HealthStatus> GetById(long healthStatusId, CancellationToken cancellationToken);
}
