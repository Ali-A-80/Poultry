using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.LightingStatuses;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.LightingStatuses;

public class LightingStatusCommandRepository : ILightingStatusCommandRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public LightingStatusCommandRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddLightingStatus(LightingStatus entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        await _context.LightingStatuses.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<LightingStatus> GetById(long lightingStatusId, CancellationToken cancellationToken)
    {
        return await _context.LightingStatuses.FirstOrDefaultAsync(x => x.Id == lightingStatusId, cancellationToken);
    }

    public async Task<bool> LightingStatusExists(long lightingStatusId, CancellationToken cancellationToken)
    {
        return await _context.LightingStatuses.AnyAsync(x => x.Id.Equals(lightingStatusId), cancellationToken);
    }

    public async Task UpdateLightingStatus(LightingStatus entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        _context.LightingStatuses.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
