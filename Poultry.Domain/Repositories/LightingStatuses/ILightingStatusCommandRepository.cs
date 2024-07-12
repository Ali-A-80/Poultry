using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.LightingStatuses;

public interface ILightingStatusCommandRepository
{
    Task<bool> LightingStatusExists(long lightingStatusId, CancellationToken cancellationToken);

    Task AddLightingStatus(LightingStatus entity, CancellationToken cancellationToken);

    Task UpdateLightingStatus(LightingStatus entity, CancellationToken cancellationToken);

    Task<LightingStatus> GetById(long lightingStatusId, CancellationToken cancellationToken);
}
