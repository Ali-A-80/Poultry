using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.VentilationSensors
{
    public class VentilationSensorCommandRepository : IVentilationSensorCommandRepository, IScopedLifetime
    {
        private readonly DatabaseContext _context;

        public VentilationSensorCommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddVentilationSensor(VentilationSensor entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            await _context.VentilationSensors.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<VentilationSensor> GetById(long ventilationSensorId, CancellationToken cancellationToken)
        {
            return await _context.VentilationSensors.FirstOrDefaultAsync(x => x.Id == ventilationSensorId, cancellationToken);
        }

        public async Task UpdateVentilationSensor(VentilationSensor entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            _context.VentilationSensors.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> VentilationSensorExists(long ventilationSensorId, CancellationToken cancellationToken)
        {
            return await _context.VentilationSensors.AnyAsync(x => x.Id == ventilationSensorId, cancellationToken);
        }
    }
}
