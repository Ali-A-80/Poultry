using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.Chickens
{
    public class ChickenCommandRepository : IChickenCommandRepository, IScopedLifetime
    {
        private readonly DatabaseContext _context;

        public ChickenCommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddChicken(Chicken entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            await _context.Chickens.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ChickenExists(long chickenId, CancellationToken cancellationToken)
        {
            return await _context.Chickens.AnyAsync(x => x.Id.Equals(chickenId), cancellationToken);
        }

        public async Task UpdateChicken(Chicken entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            _context.Chickens.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Chicken> GetChickenById(long chickenId, CancellationToken cancellationToken)
        {
            return await _context.Chickens.FirstOrDefaultAsync(x => x.Id == chickenId, cancellationToken);
        }
    }
}
