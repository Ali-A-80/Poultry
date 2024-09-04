using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.Chickens;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.Chickens;

public class ChickenQueryRepository : IChickenQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public ChickenQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IIncludableQueryable<Chicken, HealthStatus> GetAll(CancellationToken cancellationToken)
    {
        return _context.Chickens.AsNoTracking()
                                .Include(x => x.HealthStatus);
    }
}
