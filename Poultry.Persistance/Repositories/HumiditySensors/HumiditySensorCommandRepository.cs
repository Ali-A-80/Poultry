using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
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

        public async Task AddHumiditySensor(HumiditySensor entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            await _context.HumiditySensors.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<HumiditySensor> GetById(long humiditySensorId, CancellationToken cancellationToken)
        {
            return await _context.HumiditySensors.FirstOrDefaultAsync(x => x.Id == humiditySensorId, cancellationToken);
        }

        public async Task<bool> HumiditySensorExists(long humiditySensorId, CancellationToken cancellationToken)
        {
            return await _context.HumiditySensors.AnyAsync(x => x.Id.Equals(humiditySensorId), cancellationToken);
        }

        public async Task UpdateHumiditySensor(HumiditySensor entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            _context.HumiditySensors.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
