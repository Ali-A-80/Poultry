using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.HumiditySensors;

public class HumiditySensorQueryRepository : IHumiditySensorQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public HumiditySensorQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<HumiditySensor> GetAll()
    {
        return _context.HumiditySensors.AsNoTracking();
    }
}
