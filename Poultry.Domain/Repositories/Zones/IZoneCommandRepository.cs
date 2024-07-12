using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.Zones;

public interface IZoneCommandRepository
{
    Task<bool> ZoneExists(long zoneId, CancellationToken cancellationToken);

    Task<Zone> GetById(long zoneId, CancellationToken cancellationToken);

    Task AddZone(Zone entity, CancellationToken cancellationToken);

    Task UpdateZone(Zone entity, CancellationToken cancellationToken);
}
