using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.TemperatureSensors;
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

    public async Task AddTemperatureSensor(TemperatureSensor temperatureSensor, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(temperatureSensor));

        await _context.TemperatureSensors.AddAsync(temperatureSensor, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TemperatureSensor> GetById(long temperatureSensor, CancellationToken cancellationToken)
    {
        return await _context.TemperatureSensors.FirstOrDefaultAsync(x => x.Id == temperatureSensor, cancellationToken);
    }

    public async Task<bool> TemperatureSensorExists(long id, CancellationToken cancellationToken)
    {
        return await _context.TemperatureSensors.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task UpdateTemperatureSensor(TemperatureSensor temperatureSensor, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(temperatureSensor));

        _context.TemperatureSensors.Update(temperatureSensor);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
