using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.FoodServices;

public interface IFoodServiceQueryRepository
{
    IQueryable<FoodService> GetAll();
}
