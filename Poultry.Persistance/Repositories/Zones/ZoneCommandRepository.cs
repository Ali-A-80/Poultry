using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> ZoneExists(long zoneId, CancellationToken cancellationToken)
    {
        return await _context.Zones.AnyAsync(x => x.Id == zoneId, cancellationToken);
    }
}
