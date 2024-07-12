using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.FoodServices;
using Poultry.Persistance.Contexts;
using Poultry.Persistance.Lifetimes;

namespace Poultry.Persistance.Repositories.FoodServices;

public class FoodServiceQueryRepository : IFoodServiceQueryRepository, IScopedLifetime
{
    private readonly DatabaseContext _context;

    public FoodServiceQueryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<FoodService> GetAll()
    {
        return _context.FoodServices.AsNoTracking();
    }
}
