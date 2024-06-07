using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.FoodServices
{
    public interface IFoodServiceCommandRepository
    {
        Task<bool> FoodServiveExists(long foodServiceId, CancellationToken cancellationToken);

        Task AddFoodService(FoodService entiry, CancellationToken cancellationToken);

        Task UpdateFoodService(FoodService entiry, CancellationToken cancellationToken);

        Task<FoodService> GetById(long foodServiceId, CancellationToken cancellationToken);
    }
}
