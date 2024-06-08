using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.HealthStatuses
{
    public class HealthStatusCommandRepository : IHealthStatusCommandRepository, IScopedLifetime
    {
        private readonly DatabaseContext _context;

        public HealthStatusCommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddHealthStatus(HealthStatus entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            await _context.HealthStatuses.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<HealthStatus> GetById(long healthStatusId, CancellationToken cancellationToken)
        {
            return await _context.HealthStatuses.FirstOrDefaultAsync(x => x.Id == healthStatusId, cancellationToken);
        }

        public async Task<bool> HealthStatusExists(long healthStatusId, CancellationToken cancellationToken)
        {
            return await _context.HealthStatuses.AnyAsync(x => x.Id.Equals(healthStatusId), cancellationToken);
        }

        public async Task UpdateHealthStatus(HealthStatus entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            _context.HealthStatuses.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
