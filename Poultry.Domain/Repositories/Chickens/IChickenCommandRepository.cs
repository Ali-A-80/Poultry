using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.Chickens;

public interface IChickenCommandRepository
{
    Task<bool> ChickenExists(long chickenId, CancellationToken cancellationToken);

    Task AddChicken(Chicken entity, CancellationToken cancellationToken);

    Task<Chicken> GetChickenById(long chickenId, CancellationToken cancellationToken);

    Task UpdateChicken(Chicken entity, CancellationToken cancellationToken);
}
