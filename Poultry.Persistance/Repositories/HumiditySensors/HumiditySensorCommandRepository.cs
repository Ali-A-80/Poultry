using Microsoft.EntityFrameworkCore;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.HumiditySensors
{
    public class HumiditySensorCommandRepository : IHumiditySensorCommandRepository, IScopedLifetime
    {
        private readonly DatabaseContext _context;

        public HumiditySensorCommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> HumiditySensorExists(long humiditySensorId, CancellationToken cancellationToken)
        {
            return await _context.HumiditySensors.AnyAsync(x => x.Id.Equals(humiditySensorId), cancellationToken);
        }
    }
}
