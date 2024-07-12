using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.TemperatureSensors;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.TemperatureSensors;

public class TemperatureSensorQueryRepository : ITemperatureSensorQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public TemperatureSensorQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<TemperatureSensor> GetAll()
    {
        return _context.TemperatureSensors.AsNoTracking();
    }
}
