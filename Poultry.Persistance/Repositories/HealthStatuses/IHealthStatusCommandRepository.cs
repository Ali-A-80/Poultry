using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.HealthStatuses
{
    public interface IHealthStatusCommandRepository
    {
        Task<bool> HealthStatusExists(long healthStatusId, CancellationToken cancellationToken);

        Task AddHealthStatus(HealthStatus entity, CancellationToken cancellationToken);
    }
}
