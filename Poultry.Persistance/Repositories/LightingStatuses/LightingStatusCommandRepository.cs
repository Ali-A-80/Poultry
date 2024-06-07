using Microsoft.EntityFrameworkCore;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.LightingStatuses
{
    public class LightingStatusCommandRepository : ILightingStatusCommandRepository, IScopedLifetime
    {
        private readonly DatabaseContext _context;

        public LightingStatusCommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> LightingStatusExists(long lightingStatusId, CancellationToken cancellationToken)
        {
            return await _context.LightingStatuses.AnyAsync(x => x.Id.Equals(lightingStatusId), cancellationToken);
        }
    }
}
