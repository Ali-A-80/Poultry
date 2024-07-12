using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.VentilationSensors;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.VentilationSensors;

public class VentilationSensorQueryRepository : IVentilationSensorQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public VentilationSensorQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<VentilationSensor> GetAll()
    {
        return _context.VentilationSensors.AsNoTracking();
    }
}
