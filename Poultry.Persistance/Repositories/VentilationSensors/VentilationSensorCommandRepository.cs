using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> VentilationSensorExists(long ventilationSensorId, CancellationToken cancellationToken)
        {
            return await _context.VentilationSensors.AnyAsync(x => x.Id == ventilationSensorId, cancellationToken);
        }
    }
}
