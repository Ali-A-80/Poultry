using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.Zones;

public class ZoneQueryRepository : IZoneQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public ZoneQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Zone> GetAll()
    {
        return _context.Zones
            .Include(x => x.LightingStatus)
            .Include(x => x.TemperatureSensors)
            .Include(x => x.HumiditySensors)
            .Include(x => x.VentilationSensors)
            .AsNoTracking();
    }
}
