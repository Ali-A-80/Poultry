using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.LightingStatuses;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.LightingStatuses;

public class LightingStatusQueryRepository : ILightingStatusQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public LightingStatusQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<LightingStatus> GetAll()
    {
        return _context.LightingStatuses.AsNoTracking();
    }
}
