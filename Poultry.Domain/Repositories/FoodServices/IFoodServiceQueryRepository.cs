using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.FoodServices;

public interface IFoodServiceQueryRepository
{
    IQueryable<FoodService> GetAll();
}
