using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.Zones;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.Zones;

public class ZoneCommandRepository : IZoneCommandRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public ZoneCommandRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddZone(Zone entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        await _context.Zones.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Zone> GetById(long zoneId, CancellationToken cancellationToken)
    {
        return await _context.Zones.FirstOrDefaultAsync(x => x.Id == zoneId ,cancellationToken);
    }

    public async Task UpdateZone(Zone entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _context.Zones.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ZoneExists(long zoneId, CancellationToken cancellationToken)
    {
        return await _context.Zones.AnyAsync(x => x.Id == zoneId, cancellationToken);
    }
}
