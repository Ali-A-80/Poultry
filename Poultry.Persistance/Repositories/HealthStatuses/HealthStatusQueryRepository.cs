using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.HealthStatuses;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.HealthStatuses;

public class HealthStatusQueryRepository : IHealthStatusQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public HealthStatusQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<HealthStatus> GetAll()
    {
        return _context.HealthStatuses.AsNoTracking();
    }
}
