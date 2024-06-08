using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.LightingStatuses
{
    public interface ILightingStatusQueryRepository
    {
        IQueryable<LightingStatus> GetAll();
    }
}
