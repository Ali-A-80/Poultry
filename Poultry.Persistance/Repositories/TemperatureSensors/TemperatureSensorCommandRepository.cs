using Microsoft.EntityFrameworkCore;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.TemperatureSensors;

public class TemperatureSensorCommandRepository : ITemperatureSensorCommandRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public TemperatureSensorCommandRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> TemperatureSensorExists(long id, CancellationToken cancellationToken)
    {
        return await _context.TemperatureSensors.AnyAsync(x => x.Id == id, cancellationToken);
    }
}
