using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.FoodServices;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.FoodServices;

public class FoodServiceCommandRepository : IFoodServiceCommandRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public FoodServiceCommandRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddFoodService(FoodService entiry, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(entiry));

        await _context.AddAsync(entiry, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> FoodServiveExists(long foodServiceId, CancellationToken cancellationToken)
    {
        return await _context.FoodServices.AnyAsync(x => x.Id.Equals(foodServiceId), cancellationToken);
    }

    public async Task<FoodService> GetById(long foodServiceId, CancellationToken cancellationToken)
    {
        return await _context.FoodServices.FirstOrDefaultAsync(x => x.Id == foodServiceId, cancellationToken);
    }

    public async Task UpdateFoodService(FoodService entiry, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(entiry));

        _context.FoodServices.Update(entiry);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
